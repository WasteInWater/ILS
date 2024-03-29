using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.FriendlyException;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wms.Core.Service
{
    /// <summary>
    /// 系统菜单服务
    /// </summary>
    [ApiDescriptionSettings(Name = "Menu", Order = 146)]
    public class SysMenuService : ISysMenuService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SysMenu> _sysMenuRep;  // 菜单表仓储  

        private readonly IUserManager _userManager;
        private readonly ISysCacheService _sysCacheService;
        private readonly ISysUserRoleService _sysUserRoleService;
        private readonly ISysRoleMenuService _sysRoleMenuService;

        public SysMenuService(IRepository<SysMenu> sysMenuRep,
                              IUserManager userManager,
                              ISysCacheService sysCacheService,
                              ISysUserRoleService sysUserRoleService,
                              ISysRoleMenuService sysRoleMenuService)
        {
            _sysMenuRep = sysMenuRep;
            _userManager = userManager;
            _sysCacheService = sysCacheService;
            _sysUserRoleService = sysUserRoleService;
            _sysRoleMenuService = sysRoleMenuService;
        }

        /// <summary>
        /// 获取用户权限(按钮权限标识集合)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [NonAction]
        public async Task<List<string>> GetLoginPermissionList(long userId)
        {
            var permissions = await _sysCacheService.GetPermission(userId); // 先从缓存里面读取
            if (permissions == null || permissions.Count < 1)
            {
                if (!_userManager.SuperAdmin)
                {
                    var roleIdList = await _sysUserRoleService.GetUserRoleIdList(userId);
                    var menuIdList = await _sysRoleMenuService.GetRoleMenuIdList(roleIdList);
                    permissions = await _sysMenuRep.DetachedEntities.Where(u => menuIdList.Contains(u.Id))
                                                                    .Where(u => u.Type == (int)MenuType.BTN)
                                                                    .Where(u => u.Status == (int)CommonStatus.ENABLE)
                                                                    .Select(u => u.Permission).ToListAsync();
                }
                else
                {
                    permissions = await _sysMenuRep.DetachedEntities
                                                   .Where(u => u.Type == (int)MenuType.BTN)
                                                   .Where(u => u.Status == (int)CommonStatus.ENABLE)
                                                   .Select(u => u.Permission).ToListAsync();
                }
                await _sysCacheService.SetPermission(userId, permissions); // 缓存结果
            }
            return permissions;
        }

        /// <summary>
        /// 获取用户LayuiMenu菜单集合
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="appCode"></param>
        /// <returns></returns>
        [NonAction]
        public async Task<List<LayuiMenu>> GetLoginMenusDesign(long userId, string appCode=null)
        {
            List<LayuiMenu> layuiDesignTreeNodes = await _sysCacheService.GetMenu(userId,string.IsNullOrEmpty(appCode)?"default":appCode); // 先从缓存里面读取
            if (layuiDesignTreeNodes == null || layuiDesignTreeNodes.Count < 1)
            {
                var sysMenuList = new List<SysMenu>();
                // 管理员则展示所有系统菜单
                if (_userManager.SuperAdmin)
                {
                    sysMenuList = await _sysMenuRep.DetachedEntities
                                                   .Where(u => u.Status == (int)CommonStatus.ENABLE)
                                                   .Where(!string.IsNullOrEmpty(appCode),u => u.Application == appCode)
                                                   .Where(u => u.Type != (int)MenuType.BTN)
                                                   .OrderBy(u => u.Sort).ToListAsync();
                }
                else
                {
                    // 非管理员则获取自己角色所拥有的菜单集合
                    var roleIdList = await _sysUserRoleService.GetUserRoleIdList(userId);
                    var menuIdList = await _sysRoleMenuService.GetRoleMenuIdList(roleIdList);
                    sysMenuList = await _sysMenuRep.DetachedEntities
                                                   .Where(u => menuIdList.Contains(u.Id))
                                                   .Where(u => u.Status == (int)CommonStatus.ENABLE)
                                                   .Where(!string.IsNullOrEmpty(appCode), u => u.Application == appCode)
                                                   .Where(u => u.Type != (int)MenuType.BTN)
                                                   .OrderBy(u => u.Sort).ToListAsync();
                }
                // 转换成登录菜单
                layuiDesignTreeNodes = GetTreeMenus(sysMenuList, 0);
                await _sysCacheService.SetMenu(userId, string.IsNullOrEmpty(appCode) ? "default" : appCode, layuiDesignTreeNodes); // 缓存结果
            }
            return layuiDesignTreeNodes;
        }
        /// <summary>
        /// 获取layui菜单树
        /// </summary>
        private List<LayuiMenu> GetTreeMenus(List<SysMenu> menus, long? pid)
        {
            var LayuiDesignMenus = new List<LayuiMenu>();
            foreach (var menu in menus.FindAll(r => r.Pid == pid))
            {
                if (menu.Type == (int)MenuType.DIR || menu.Type == (int)MenuType.MENU)
                {
                    var menuSecurity = new LayuiMenu
                    {
                        Id = menu.Id,
                        Title = menu.Name,
                        Href = menu.Component,
                        Icon = menu.Icon,
                        OpenType = "_iframe",
                        Type = menu.Type

                    };
                    menuSecurity.Children = GetTreeMenus(menus, menu.Id);
                    LayuiDesignMenus.Add(menuSecurity);
                }
            }
            return LayuiDesignMenus;
        }

        /// <summary>
        /// 获取用户菜单所属的应用编码集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [NonAction]
        public async Task<List<string>> GetUserMenuAppCodeList(long userId)
        {
            var roleIdList = await _sysUserRoleService.GetUserRoleIdList(userId);
            var menuIdList = await _sysRoleMenuService.GetRoleMenuIdList(roleIdList);
            return await _sysMenuRep.DetachedEntities.Where(u => menuIdList.Contains(u.Id))
                                                     .Where(u => u.Status == (int)CommonStatus.ENABLE)
                                                     .Select(u => u.Application).ToListAsync();
        }

        /// <summary>
        /// 系统菜单列表（树表）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysMenu/list")]
        public async Task<dynamic> GetMenuList([FromQuery] MenuInput input)
        {
            var application = !string.IsNullOrEmpty(input.Application?.Trim());
            var name = !string.IsNullOrEmpty(input.Name?.Trim());
            var menus = await _sysMenuRep.DetachedEntities.Where((application, u => u.Application == input.Application.Trim()),
                                                                 (name, u => EF.Functions.Like(u.Name, $"%{input.Name.Trim()}%")))
                                                          .Where(u => u.Status == (int)CommonStatus.ENABLE).OrderBy(u => u.Sort)
                                                          .Select(u => u.Adapt<MenuOutput>())
                                                          .ToListAsync();
            return menus;
        }

        
        /// <summary>
        /// 增加和编辑时检查参数
        /// </summary>
        /// <param name="input"></param>
        private static void CheckMenuParam(MenuInput input)
        {
            var type = input.Type;
            var router = input.Router;
            var permission = input.Permission;
            var openType = input.OpenType;

            if (type.Equals((int)MenuType.DIR))
            {
                if (string.IsNullOrEmpty(router))
                    throw Oops.Oh(ErrorCode.D4001);
            }
            else if (type.Equals((int)MenuType.MENU))
            {
                if (string.IsNullOrEmpty(router))
                    throw Oops.Oh(ErrorCode.D4001);
                if (openType>4||openType<0)
                    throw Oops.Oh(ErrorCode.D4002);
            }
            else if (type.Equals((int)MenuType.BTN))
            {
                if (string.IsNullOrEmpty(permission))
                    throw Oops.Oh(ErrorCode.D4003);
                if (!permission.Contains(":"))
                    throw Oops.Oh(ErrorCode.D4004);        
            }
        }

        /// <summary>
        /// 增加系统菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/sysMenu/add")]
        public async Task AddMenu(AddMenuInput input)
        {
            var isExist = await _sysMenuRep.DetachedEntities.AnyAsync(u => u.Code == input.Code); 
            if (isExist)
                throw Oops.Oh(ErrorCode.D4000);

            // 校验参数
            CheckMenuParam(input);

            var menu = input.Adapt<SysMenu>();
            menu.Pids = await CreateNewsPids(input.Pid);
            menu.Status = (int)CommonStatus.ENABLE;
            await menu.InsertAsync();
            // 清除缓存
            await _sysCacheService.DelByPatternAsync(CommonConst.CACHE_KEY_MENU);
        }

        /// <summary>
        /// 创建Pids格式 
        /// 如果pid是0顶级节点，pids就是 [0];
        /// 如果pid不是顶级节点，pids就是 pid菜单的 pids + [pid] + ,
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        private async Task<string> CreateNewsPids(long pid)
        {
            if (pid == 0L)
            {
                return "[0],";
            }
            else
            {
                var pmenu = await _sysMenuRep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == pid);
                return pmenu.Pids + "[" + pid + "],";
            }
        }

        /// <summary>
        /// 删除系统菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/sysMenu/delete")]
        [UnitOfWork]
        public async Task DeleteMenu(DeleteMenuInput input)
        {
            var childIdList = await _sysMenuRep.DetachedEntities.Where(u => u.Pids.Contains(input.Id.ToString()))
                                                                .Select(u => u.Id).ToListAsync();
            childIdList.Add(input.Id);

            var menus = await _sysMenuRep.Where(u => childIdList.Contains(u.Id)).ToListAsync();
            menus.ForEach(u =>
            {
                u.Delete();
            });
            // 级联删除该菜单及子菜单对应的角色-菜单表信息
            await _sysRoleMenuService.DeleteRoleMenuListByMenuIdList(childIdList);

            // 清除缓存
            await _sysCacheService.DelByPatternAsync(CommonConst.CACHE_KEY_MENU);
        }

        /// <summary>
        /// 更新系统菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/sysMenu/edit"),]
        public async Task UpdateMenu(UpdateMenuInput input)
        {
            // Pid和Id不能一致，一致会导致无限递归
            if (input.Id == input.Pid)
                throw Oops.Oh(ErrorCode.D4006);

            var isExist = await _sysMenuRep.DetachedEntities.AnyAsync(u => u.Code == input.Code && u.Id != input.Id); // u.Name == input.Name
            if (isExist)
                throw Oops.Oh(ErrorCode.D4000);

            // 校验参数
            CheckMenuParam(input);
            // 如果是编辑，父id不能为自己的子节点
            var childIdList = await _sysMenuRep.DetachedEntities.Where(u => u.Pids.Contains(input.Id.ToString()))
                                                                .Select(u => u.Id).ToListAsync();
            if (childIdList.Contains(input.Pid))
                throw Oops.Oh(ErrorCode.D4006);

            var oldMenu = await _sysMenuRep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);

            // 生成新的pids
            var newPids = await CreateNewsPids(input.Pid);

            // 是否更新子应用的标识
            var updateSubAppsFlag = false;
            // 是否更新子节点的pids的标识
            var updateSubPidsFlag = false;

            // 如果应用有变化
            if (input.Application != oldMenu.Application)
            {
                // 父节点不是根节点不能移动应用
                if (oldMenu.Pid != 0L)
                    throw Oops.Oh(ErrorCode.D4007);
                updateSubAppsFlag = true;
            }
            // 父节点有变化
            if (input.Pid != oldMenu.Pid)
                updateSubPidsFlag = true;

            // 开始更新所有子节点的配置
            if (updateSubAppsFlag || updateSubPidsFlag)
            {
                // 查找所有叶子节点，包含子节点的子节点
                var menuList = await _sysMenuRep.Where(u => EF.Functions.Like(u.Pids, $"%{oldMenu.Id}%")).ToListAsync();
                // 更新所有子节点的应用为当前菜单的应用
                if (menuList.Count > 0)
                {
                    // 更新所有子节点的application
                    if (updateSubAppsFlag)
                    {
                        menuList.ForEach(u =>
                        {
                            u.Application = input.Application;
                        });
                    }

                    // 更新所有子节点的pids
                    if (updateSubPidsFlag)
                    {
                        menuList.ForEach(u =>
                        {
                            // 子节点pids组成 = 当前菜单新pids + 当前菜单id + 子节点自己的pids后缀
                            var oldParentCodesPrefix = oldMenu.Pids + "[" + oldMenu.Id + "],";
                            var oldParentCodesSuffix = u.Pids.Substring(oldParentCodesPrefix.Length);
                            var menuParentCodes = newPids + "[" + oldMenu.Id + "]," + oldParentCodesSuffix;
                            u.Pids = menuParentCodes;
                        });
                    }
                }
            }

            // 更新当前菜单
            oldMenu = input.Adapt<SysMenu>();
            oldMenu.Pids = newPids;
            await oldMenu.UpdateAsync(ignoreNullValues: true);

            // 清除缓存
            await _sysCacheService.DelByPatternAsync(CommonConst.CACHE_KEY_MENU);
        }

        /// <summary>
        /// 获取系统菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/sysMenu/detail")]
        public async Task<dynamic> GetMenu(QueryMenuInput input)
        {
            return await _sysMenuRep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取系统菜单树，用于新增、编辑时选择上级节点
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysMenu/tree")]
        public async Task<dynamic> GetMenuTree([FromQuery] MenuInput input)
        {
            var application = !string.IsNullOrEmpty(input.Application?.Trim());
            var menus = await _sysMenuRep.DetachedEntities
                                         .Where(application, u => u.Application == input.Application.Trim())
                                         .Where(u => u.Status == (int)CommonStatus.ENABLE)
                                         .Where(u => u.Type == (int)MenuType.DIR || u.Type == (int)MenuType.MENU)
                                         .OrderBy(u => u.Sort)
                                         .Select(u => 
                                         new MenuTreeOutput
                                         {
                                             Id = u.Id,
                                             ParentId = u.Pid,
                                             Title = u.Name,
                                         }).ToListAsync();

            menus.ForEach(m =>  m.Last =_sysMenuRep.Any(u => u.Pid.Equals(m.Id)));
           
            return new TreeBuildUtil<MenuTreeOutput>().DoTreeBuild(menus);
        }

        /// <summary>
        /// 获取系统菜单树，用于给角色授权时选择
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/sysMenu/treeForGrant")]
        public async Task<dynamic> TreeForGrant([FromQuery] MenuInput input)
        {
            var menuIdList = new List<long>();
            if (!_userManager.SuperAdmin)
            {
                var roleIdList = await _sysUserRoleService.GetUserRoleIdList(_userManager.UserId);
                menuIdList = await _sysRoleMenuService.GetRoleMenuIdList(roleIdList);
            }

            var application = !string.IsNullOrEmpty(input.Application?.Trim());
            var menus = await _sysMenuRep.DetachedEntities
                                         .Where(application, u => u.Application == input.Application.Trim())
                                         .Where(u => u.Status == (int)CommonStatus.ENABLE)
                                         .Where(menuIdList.Count > 0, u => menuIdList.Contains(u.Id))
                                         .OrderBy(u => u.Sort).Select(u => new MenuTreeOutput
                                         {
                                             Id = u.Id,
                                             ParentId = u.Pid,
                                             Title = u.Name,
                                         }).ToListAsync();

            menus.ForEach(m => m.Last = _sysMenuRep.Any(u => u.Pid.Equals(m.Id)));
            return new TreeBuildUtil<MenuTreeOutput>().DoTreeBuild(menus);
        }

        /// <summary>
        /// 根据应用编码判断该机构下是否有状态为正常的菜单
        /// </summary>
        /// <param name="appCode"></param>
        /// <returns></returns>
        [NonAction]
        public async Task<bool> HasMenu(string appCode)
        {
            return await _sysMenuRep.DetachedEntities.AnyAsync(u => u.Application == appCode && u.Status != CommonStatus.DELETED);
        }

       /// <summary>
       /// 加载系统菜单
       /// </summary>
       /// <returns></returns>
        [HttpGet("/sysMenu/change")]
        [NonUnify]
        public async Task<List<LayuiMenu>> ChangeAppMenu()
        {
            return await GetLoginMenusDesign(_userManager.UserId);
        }
    }
}
