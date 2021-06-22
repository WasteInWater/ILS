using Furion;
using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DataEncryption;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UAParser;

namespace Wms.Core.Service
{
    /// <summary>
    /// 登录授权相关服务
    /// </summary>
    [ApiDescriptionSettings(Name = "Auth", Order = 160)]
    [Area("User")]
    public class AuthService : IAuthService, IDynamicApiController, ITransient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IRepository<SysUser> _sysUserRep;     // 用户表仓储
        private readonly IUserManager _userManager; // 用户管理

        private readonly ISysUserService _sysUserService; // 系统用户服务
        private readonly ISysEmpService _sysEmpService;   // 系统员工服务
        private readonly ISysRoleService _sysRoleService; // 系统角色服务
        private readonly ISysMenuService _sysMenuService; // 系统菜单服务
       

        public AuthService(IRepository<SysUser> sysUserRep,
                           IHttpContextAccessor httpContextAccessor,
                           IUserManager userManager,
                           ISysUserService sysUserService,
                           ISysEmpService sysEmpService,
                           ISysRoleService sysRoleService,
                           ISysMenuService sysMenuService
                           )
        {
            _sysUserRep = sysUserRep;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _sysUserService = sysUserService;
            _sysEmpService = sysEmpService;
            _sysRoleService = sysRoleService;
            _sysMenuService = sysMenuService;
            
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        [HttpPost("/User/login")]
        [AllowAnonymous]
        public string LoginAsync([Required] LoginInput input)
        {
            // 获取加密后的密码
            var encryptPasswod = MD5Encryption.Encrypt(input.Password);

            // 判断用户名和密码是否正确 忽略全局过滤器
            var user = _sysUserRep.Where(u => u.Account.Equals(input.Account) && u.Password.Equals(encryptPasswod), null, true).FirstOrDefault();
            _ = user ?? throw Oops.Oh(ErrorCode.D1000);

            // 验证账号是否被冻结
            if (user.Status == CommonStatus.DISABLE)
                throw Oops.Oh(ErrorCode.D1017);

            // 生成Token令牌
            var accessToken = JWTEncryption.Encrypt(new Dictionary<string, object>
            {
                { ClaimConst.Claim_UserId, user.Id },
                { ClaimConst.Claim_Account, user.Account },
                { ClaimConst.Claim_Name, user.Name },
                { ClaimConst.Claim_SuperAdmin, user.AdminType },
            });

            // 设置Swagger自动登录
            _httpContextAccessor.SigninToSwagger(accessToken);

            // 生成刷新Token令牌
            var refreshToken = JWTEncryption.GenerateRefreshToken(accessToken, 7);

            var expiretime = App.Configuration["JWTSettings:ExpiredTime"];
            // 设置刷新Token令牌
            _httpContextAccessor.HttpContext.Response.Headers["x-access-token"] = refreshToken;
            
            _httpContextAccessor.HttpContext.Response.Headers["token-expiretime"] = expiretime;
           
            return accessToken;
        }

        /// <summary>
        /// 获取当前登录用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("/getLoginUser")]
        public async Task<LoginOutput> GetLoginUserAsync()
        {
            var user = _userManager.User;
            var userId = user.Id;

            var httpContext = App.GetService<IHttpContextAccessor>().HttpContext;
            var loginOutput = user.Adapt<LoginOutput>();

            loginOutput.LastLoginTime = user.LastLoginTime = DateTimeOffset.Now;
            var ip = httpContext.Request.Headers["X-Real-IP"].FirstOrDefault();
            loginOutput.LastLoginIp = user.LastLoginIp = string.IsNullOrEmpty(user.LastLoginIp) ? httpContext.GetRemoteIpAddressToIPv4() : ip;

            //var ipInfo = IpTool.Search(loginOutput.LastLoginIp);
            //loginOutput.LastLoginAddress = ipInfo.Country + ipInfo.Province + ipInfo.City + "[" + ipInfo.NetworkOperator + "][" + ipInfo.Latitude + ipInfo.Longitude + "]";

            var clent = Parser.GetDefault().Parse(httpContext.Request.Headers["User-Agent"]);
            loginOutput.LastLoginBrowser = clent.UA.Family + clent.UA.Major;
            loginOutput.LastLoginOs = clent.OS.Family + clent.OS.Major;

            // 员工信息
            loginOutput.LoginEmpInfo = await _sysEmpService.GetEmpInfo(userId);

            //// 角色信息
            //loginOutput.Roles = await _sysRoleService.GetUserRoleList(userId);

            //// 权限信息
            //loginOutput.Permissions = await _sysMenuService.GetLoginPermissionList(userId);

            //// 数据范围信息(机构Id集合)
            //loginOutput.DataScopes = await _sysUserService.GetUserDataScopeIdList(userId);

            //loginOutput.Menus = await _sysMenuService.GetLoginMenusDesign(userId,null);
            // 菜单信息

            // 登录日志入库
            await new SysLogVis
            {
                Name = loginOutput.Name,
                Success = YesOrNot.Y,
                Message = "登录成功",
                Ip = loginOutput.LastLoginIp,
                Browser = loginOutput.LastLoginBrowser,
                Os = loginOutput.LastLoginOs,
                VisType = LoginType.LOGIN,
                VisTime = loginOutput.LastLoginTime,
                Account = loginOutput.Account
            }.InsertAsync();

            return loginOutput;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <returns></returns>
        [HttpGet("/logout")]
        public async Task LogoutAsync()
        {
            var user = _userManager.User;
            _httpContextAccessor.SignoutToSwagger();
            _httpContextAccessor.HttpContext.Response.Headers["access-token"] = "invalid token";

            // 增加退出日志
            await new SysLogVis
            {
                Name = user.Name,
                Success = YesOrNot.Y,
                Message = "退出成功",
                VisType = LoginType.LOGOUT,
                VisTime = DateTimeOffset.Now,
                Account = user.Account
            }.InsertAsync();

            await Task.CompletedTask;
        }
    }
}
