using Furion;
using Furion.Authorization;
using Furion.DataEncryption;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wms.Core;

namespace Wms.Web.Core.AuthHandlers
{
    public class JwtHandler : AppAuthorizeHandler
    {
        /// <summary>
        /// 重写 Handler 添加自动刷新收取逻辑
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task HandleAsync(AuthorizationHandlerContext context)
        {
            //var pendingRequirements = context.PendingRequirements;

            //// 获取 HttpContext 上下文
             var httpContext = context.GetCurrentHttpContext();
            
            //if (httpContext.GetMetadata<SecurityDefineAttribute>() != null) {
            //    var pipeline = await PipelineAsync(context, httpContext);
            //    if (pipeline)
            //    {
            //        foreach (var requirement in pendingRequirements)
            //        {
            //            context.Succeed(requirement);

            //        }
            //    }
            //}
            // 自动刷新 token
            if (JWTEncryption.AutoRefreshToken(context, httpContext, null, 7))
            {
                await AuthorizeHandleAsync(context);
            }
            else context.Fail();    // 授权失败

        }
            

        /// <summary>
        /// 验证管道，也就是验证核心代码
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public override async Task<bool> PipelineAsync(AuthorizationHandlerContext context, DefaultHttpContext httpContext)
        {
            // 检查权限，如果方法时异步的就不用 Task.FromResult 包裹，直接使用 async/await 即可
            return await CheckAuthorizeAsync(httpContext);
        }

        /// <summary>
        /// 验证权限
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private static async Task<bool> CheckAuthorizeAsync(DefaultHttpContext httpContext)
        {

            // 管理员跳过判断
            var userManager = App.GetService<IUserManager>();
            //var sysCache = App.GetService<Wms.Core.Service.ISysCacheService>();

            //List<OnlineUser> onlines = await sysCache.GetAsync<List<OnlineUser>>(CommonConst.CACHE_KEY_ONLINE_USER);

            //if (!onlines.Select(u => u.UserId).Contains(userManager.UserId)) return false;

            //if (userManager.SuperAdmin) return true;

            // 路由名称
            var routeName = httpContext.Request.Path.Value[1..].Replace("/", ":");
            var item = routeName.Split(":");

            // 默认路由(获取登录用户信息)
            var defalutRoute = new List<string>()
            {
                "getLoginUser",
                "sysMenu:change"
            };
            var isExitListstring = item[^1].ToLower().Equals("list");

            if (defalutRoute.Contains(routeName)||isExitListstring) return true;

            // 获取用户权限集合（按钮或API接口）
            var permissionList = await App.GetService<Wms.Core.Service.ISysMenuService>().GetLoginPermissionList(userManager.UserId);

            // 检查授权
            return permissionList.Contains(routeName);
        }
    }
}
