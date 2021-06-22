using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Wms.Core
{
    /// <summary>
    /// 系统菜单表种子数据
    /// </summary>
    public class SysMenuSeedData : IEntitySeedData<SysMenu>
    {
        /// <summary>
        /// 种子数据
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="dbContextLocator"></param>
        /// <returns></returns>
        public IEnumerable<SysMenu> HasData(DbContext dbContext, Type dbContextLocator)
        {
            return new[]
            {
                new SysMenu{Id=142307070910560, Pid=0, Pids="[0],", Name="主控面板", Code="system_index", Type=0, Icon="layui-icon layui-icon-chart-screen", Router="/", Component="", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=1, Status=0 },
                new SysMenu{Id=142307070910561, Pid=142307070910560, Pids="[0],[142307070910560],", Name="分析页", Code="system_index_dashboard", Type=1, Router="analysis", Component="system/dashboard/Analysis", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910562, Pid=142307070910560, Pids="[0],[142307070910560],", Name="工作台", Code="system_index_workplace", Type=1, Router="workplace", Component="system/dashboard/Workplace", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },

                //system
                new SysMenu{Id=142307070910563, Pid=0, Pids="[0],", Name="系统管理", Code="sys_mgr", Type=0, Icon="layui-icon layui-icon-set", Router="/sys", Component="", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                
                new SysMenu{Id=142307070910564, Pid=142307070910563, Pids="[0],[142307070910563],", Name="用户管理", Code="sys_user_mgr", Type=1, Router="/mgr_user", Component="system/user/index", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910565, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户查询", Code="sys_user_mgr_page", Type=2, Permission="sysUser:page", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910566, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户编辑", Code="sys_user_mgr_edit", Type=2, Permission="sysUser:edit", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910567, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户增加", Code="sys_user_mgr_add", Type=2, Permission="sysUser:add", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070910568, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户删除", Code="sys_user_mgr_delete", Type=2, Permission="sysUser:delete", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070910569, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户详情", Code="sys_user_mgr_detail", Type=2, Permission="sysUser:detail", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910570, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户导出", Code="sys_user_mgr_export", Type=2, Permission="sysUser:export", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910571, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户选择器", Code="sys_user_mgr_selector", Type=2, Permission="sysUser:selector", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910572, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户授权角色", Code="sys_user_mgr_grant_role", Type=2, Permission="sysUser:grantRole", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910573, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户拥有角色", Code="sys_user_mgr_own_role", Type=2, Permission="sysUser:ownRole", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910574, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户授权数据", Code="sys_user_mgr_grant_data", Type=2, Permission="sysUser:grantData", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910575, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户拥有数据", Code="sys_user_mgr_own_data", Type=2, Permission="sysUser:ownData", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910576, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户更新信息", Code="sys_user_mgr_update_info", Type=2, Permission="sysUser:updateInfo", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910577, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户修改密码", Code="sys_user_mgr_update_pwd", Type=2, Permission="sysUser:updatePwd", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910578, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户修改状态", Code="sys_user_mgr_change_status", Type=2, Permission="sysUser:changeStatus", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910579, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户修改头像", Code="sys_user_mgr_update_avatar", Type=2, Permission="sysUser:updateAvatar", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070910580, Pid=142307070910564, Pids="[0],[142307070910563],[142307070910564],", Name="用户重置密码", Code="sys_user_mgr_reset_pwd", Type=2, Permission="sysUser:resetPwd", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
               
                new SysMenu{Id=142307070910581, Pid=142307070910563, Pids="[0],[142307070910563],", Name="机构管理", Code="sys_org_mgr", Type=1, Router="/org", Component="system/org/index", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910582, Pid=142307070910581, Pids="[0],[142307070910563],[142307070910581],", Name="机构查询", Code="sys_org_mgr_page", Type=2, Permission="sysOrg:page", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910583, Pid=142307070910581, Pids="[0],[142307070910563],[142307070910581],", Name="机构列表", Code="sys_org_mgr_list", Type=2, Permission="sysOrg:list", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910584, Pid=142307070910581, Pids="[0],[142307070910563],[142307070910581],", Name="机构增加", Code="sys_org_mgr_add", Type=2, Permission="sysOrg:add", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910585, Pid=142307070910581, Pids="[0],[142307070910563],[142307070910581],", Name="机构编辑", Code="sys_org_mgr_edit", Type=2, Permission="sysOrg:edit", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910586, Pid=142307070910581, Pids="[0],[142307070910563],[142307070910581],", Name="机构删除", Code="sys_org_mgr_delete", Type=2, Permission="sysOrg:delete", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070910587, Pid=142307070910581, Pids="[0],[142307070910563],[142307070910581],", Name="机构详情", Code="sys_org_mgr_detail", Type=2, Permission="sysOrg:detail", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910588, Pid=142307070910581, Pids="[0],[142307070910563],[142307070910581],", Name="机构树", Code="sys_org_mgr_tree", Type=2, Permission="sysOrg:tree", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0},
                
                new SysMenu{Id=142307070910589, Pid=142307070910563, Pids="[0],[142307070910563],", Name="职位管理", Code="sys_pos_mgr", Type=1, Router="/pos", Component="system/pos/index", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070910590, Pid=142307070910589, Pids="[0],[142307070910563],[142307070910589],", Name="职位查询", Code="sys_pos_mgr_page", Type=2, Permission="sysPos:page", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910591, Pid=142307070910589, Pids="[0],[142307070910563],[142307070910589],", Name="职位列表", Code="sys_pos_mgr_list", Type=2, Permission="sysPos:list", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910592, Pid=142307070910589, Pids="[0],[142307070910563],[142307070910589],", Name="职位增加", Code="sys_pos_mgr_add", Type=2, Permission="sysPos:add", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910593, Pid=142307070910589, Pids="[0],[142307070910563],[142307070910589],", Name="职位编辑", Code="sys_pos_mgr_edit", Type=2, Permission="sysPos:edit", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070910594, Pid=142307070910589, Pids="[0],[142307070910563],[142307070910589],", Name="职位删除", Code="sys_pos_mgr_delete", Type=2, Permission="sysPos:delete", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910595, Pid=142307070910589, Pids="[0],[142307070910563],[142307070910589],", Name="职位详情", Code="sys_pos_mgr_detail", Type=2, Permission="sysPos:detail", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },

                new SysMenu{Id=142307070910596, Pid=142307070910563, Pids="[0],[142307070910563],", Name="角色管理", Code="sys_role_mgr", Type=1, Router="/role", Component="system/role/index", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070910597, Pid=142307070910596, Pids="[0],[142307070910563],[142307070910596],", Name="角色查询", Code="sys_role_mgr_page", Type=2, Permission="sysRole:page", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910598, Pid=142307070910596, Pids="[0],[142307070910563],[142307070910596],", Name="角色增加", Code="sys_role_mgr_add", Type=2, Permission="sysRole:add", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910599, Pid=142307070910596, Pids="[0],[142307070910563],[142307070910596],", Name="角色编辑", Code="sys_role_mgr_edit", Type=2, Permission="sysRole:edit", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910600, Pid=142307070910596, Pids="[0],[142307070910563],[142307070910596],", Name="角色删除", Code="sys_role_mgr_delete", Type=2, Permission="sysRole:delete", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910601, Pid=142307070910596, Pids="[0],[142307070910563],[142307070910596],", Name="角色详情", Code="sys_role_mgr_detail", Type=2, Permission="sysRole:detail", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910602, Pid=142307070910596, Pids="[0],[142307070910563],[142307070910596],", Name="角色下拉", Code="sys_role_mgr_drop_down", Type=2, Permission="sysRole:dropDown", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910603, Pid=142307070910596, Pids="[0],[142307070910563],[142307070910596],", Name="角色授权菜单", Code="sys_role_mgr_grant_menu", Type=2, Permission="sysRole:grantMenu", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910604, Pid=142307070910596, Pids="[0],[142307070910563],[142307070910596],", Name="角色拥有菜单", Code="sys_role_mgr_own_menu", Type=2, Permission="sysRole:ownMenu", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910605, Pid=142307070910596, Pids="[0],[142307070910563],[142307070910596],", Name="角色授权数据", Code="sys_role_mgr_grant_data", Type=2, Permission="sysRole:grantData", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910606, Pid=142307070910596, Pids="[0],[142307070910563],[142307070910596],", Name="角色拥有数据", Code="sys_role_mgr_own_data", Type=2, Permission="sysRole:ownData", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },

                new SysMenu{Id=142307070910607, Pid=142307070910563, Pids="[0],[142307070910563],", Name="字典管理", Code="sys_dict_mgr", Type=1, Router="/dict", Component="system/dict/index", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070910608, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典类型查询", Code="sys_dict_mgr_dict_type_page", Type=2, Permission="sysDictType:page", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910609, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典类型列表", Code="sys_dict_mgr_dict_type_list", Type=2, Permission="sysDictType:list", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910610, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典类型增加", Code="sys_dict_mgr_dict_type_add", Type=2, Permission="sysDictType:add", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910611, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典类型删除", Code="sys_dict_mgr_dict_type_delete", Type=2, Permission="sysDictType:delete", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910612, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典类型编辑", Code="sys_dict_mgr_dict_type_edit", Type=2, Permission="sysDictType:edit", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910613, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典类型详情", Code="sys_dict_mgr_dict_type_detail", Type=2, Permission="sysDictType:detail", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910614, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典类型下拉", Code="sys_dict_mgr_dict_type_drop_down", Type=2, Permission="sysDictType:dropDown", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910615, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典类型修改状态", Code="sys_dict_mgr_dict_type_change_status", Type=2, Permission="sysDictType:changeStatus", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910616, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典值查询", Code="sys_dict_mgr_dict_page", Type=2, Permission="sysDictData:page", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910617, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典值列表", Code="sys_dict_mgr_dict_list", Type=2, Permission="sysDictData:list", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910618, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典值增加", Code="sys_dict_mgr_dict_add", Type=2, Permission="sysDictData:add", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910619, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典值删除", Code="sys_dict_mgr_dict_delete", Type=2, Permission="sysDictData:delete", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910620, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典值编辑", Code="sys_dict_mgr_dict_edit", Type=2, Permission="sysDictData:edit", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910621, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典值详情", Code="sys_role_mgr_grant_data", Type=2, Permission="sysDictData:detail", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910622, Pid=142307070910607, Pids="[0],[142307070910563],[142307070910607],", Name="字典值修改状态", Code="sys_dict_mgr_dict_change_status", Type=2, Permission="sysDictData:changeStatus", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },

                new SysMenu{Id=142307070910623, Pid=142307070910563, Pids="[0],[142307070910563],", Name="系统文件", Code="sys_file_mgr_sys_file", Type=1, Router="/file", Component="system/file/index", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910624, Pid=142307070910623, Pids="[0],[142307070910563],[142307070910623],", Name="文件查询", Code="sys_file_mgr_sys_file_page", Type=2, Permission="sysFileInfo:page", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910625, Pid=142307070910623, Pids="[0],[142307070910563],[142307070910623],", Name="文件列表", Code="sys_file_mgr_sys_file_list", Type=2, Permission="sysFileInfo:list", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910626, Pid=142307070910623, Pids="[0],[142307070910563],[142307070910623],", Name="文件删除", Code="sys_file_mgr_sys_file_delete", Type=2, Permission="sysFileInfo:delete", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910627, Pid=142307070910623, Pids="[0],[142307070910563],[142307070910623],", Name="文件详情", Code="sys_file_mgr_sys_file_detail", Type=2, Permission="sysFileInfo:detail", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910628, Pid=142307070910623, Pids="[0],[142307070910563],[142307070910623],", Name="文件上传", Code="sys_file_mgr_sys_file_upload", Type=2, Permission="sysFileInfo:upload", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910629, Pid=142307070910623, Pids="[0],[142307070910563],[142307070910623],", Name="文件下载", Code="sys_file_mgr_sys_file_download", Type=2, Permission="sysFileInfo:download", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910630, Pid=142307070910623, Pids="[0],[142307070910563],[142307070910623],", Name="图片预览", Code="sys_file_mgr_sys_file_preview", Type=2, Permission="sysFileInfo:preview", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },

                //开发管理
                new SysMenu{Id=142307070910811, Pid=0, Pids="[0],", Name="开发管理", Code="system_tools", Type=0, Icon="layui-icon layui-icon-component", Router="/tools", Component="", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },

                new SysMenu{Id=142307070910812, Pid=142307070910811, Pids="[0],[142307070910811],", Name="菜单管理", Code="sys_menu_mgr", Type=1, Router="/menu", Component="system/menu/index", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070910813, Pid=142307070910812, Pids="[0],[142307070910811],[142307070910812],", Name="菜单列表", Code="sys_menu_mgr_list", Type=2, Permission="sysMenu:list", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910814, Pid=142307070910812, Pids="[0],[142307070910811],[142307070910812],", Name="菜单增加", Code="sys_menu_mgr_add", Type=2, Permission="sysMenu:add", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910815, Pid=142307070910812, Pids="[0],[142307070910811],[142307070910812],", Name="菜单编辑", Code="sys_menu_mgr_edit", Type=2, Permission="sysMenu:edit", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910816, Pid=142307070910812, Pids="[0],[142307070910811],[142307070910812],", Name="菜单删除", Code="sys_menu_mgr_delete", Type=2, Permission="sysMenu:delete", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910817, Pid=142307070910812, Pids="[0],[142307070910811],[142307070910812],", Name="菜单详情", Code="sys_menu_mgr_detail", Type=2, Permission="sysMenu:detail", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910818, Pid=142307070910812, Pids="[0],[142307070910811],[142307070910812],", Name="菜单授权树", Code="sys_menu_mgr_grant_tree", Type=2, Permission="sysMenu:treeForGrant", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910819, Pid=142307070910812, Pids="[0],[142307070910811],[142307070910812],", Name="菜单树", Code="sys_menu_mgr_tree", Type=2, Permission="sysMenu:tree", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910820, Pid=142307070910812, Pids="[0],[142307070910811],[142307070910812],", Name="菜单切换", Code="sys_menu_mgr_change", Type=2, Permission="sysMenu:change", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070910821, Pid=142307070910811, Pids="[0],[142307070910811],", Name="接口文档", Code="sys_swagger_mgr", Type=1, Router="/swagger", Component="/swagger/index.html", Application="system", OpenType=2, Visible="Y", Weight=1, Sort=100, Status=0},

                //系统监控
                new SysMenu{Id=142307070911501, Pid=0, Pids="[0],", Name="系统监控", Code="sys_monitor_mgr", Type=0, Icon="layui-icon layui-icon-console", Router="/monitor", Component="", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                
                new SysMenu{Id=142307070911502, Pid=142307070911501, Pids="[0],[142307070911501],", Name="服务监控", Code="sys_monitor_mgr_machine_monitor", Type=1, Router="/machine", Component="system/monitor/machine", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070911503, Pid=142307070911502, Pids="[0],[142307070911501],[142307070911502],", Name="服务监控查询", Code="sys_monitor_mgr_machine_monitor_query", Type=2, Permission="sysMachine:query", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                
                new SysMenu{Id=142307070911504, Pid=142307070911501, Pids="[0],[142307070911501],", Name="在线用户", Code="sys_monitor_mgr_online_user", Type=1, Router="/onlineUser", Component="system/monitor/onlineUser", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070911505, Pid=142307070911504, Pids="[0],[142307070911501],[142307070911504],", Name="在线用户列表", Code="sys_monitor_mgr_online_user_list", Type=2, Permission="sysOnlineUser:list", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070911506, Pid=142307070911504, Pids="[0],[142307070911501],[142307070911504],", Name="在线用户强退", Code="sys_monitor_mgr_online_user_force_exist", Type=2, Permission="sysOnlineUser:forceExist", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
               
                new SysMenu{Id=142307070911507, Pid=142307070911501, Pids="[0],[142307070911501],", Name="数据监控", Code="sys_monitor_mgr_druid", Type=1, Router="/druid", Component="system/monitor/druid", Application="system", OpenType=2, Visible="N",  Weight=1, Sort=100, Status=0},


                //
                new SysMenu{Id=142307070911601, Pid=0, Pids="[0],", Name="日志管理", Code="sys_log_mgr", Type=0, Icon="layui-icon layui-icon-tabs", Router="/log", Component="", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                
                new SysMenu{Id=142307070911602, Pid=142307070911601, Pids="[0],[142307070911601],", Name="访问日志", Code="sys_log_mgr_vis_log", Type=1, Router="/vislog", Component="system/log/vislog", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070911603, Pid=142307070911602, Pids="[0],[142307070911601],[142307070911602],", Name="访问日志查询", Code="sys_log_mgr_vis_log_page", Type=2, Permission="sysVisLog:page", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070911604, Pid=142307070911602, Pids="[0],[142307070911601],[142307070911602],", Name="访问日志清空", Code="sys_log_mgr_vis_log_delete", Type=2, Permission="sysVisLog:delete", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                
                new SysMenu{Id=142307070911605, Pid=142307070911601, Pids="[0],[142307070911601],", Name="操作日志", Code="sys_log_mgr_op_log", Type=1, Router="/oplog", Component="system/log/oplog", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070911606, Pid=142307070911605, Pids="[0],[142307070911601],[142307070911605],", Name="操作日志查询", Code="sys_log_mgr_op_log_page", Type=2, Permission="sysOpLog:page", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070911607, Pid=142307070911605, Pids="[0],[142307070911601],[142307070911605],", Name="操作日志清空", Code="sys_log_mgr_op_log_delete", Type=2, Permission="sysOpLog:delete", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                
                new SysMenu{Id=142307070911608, Pid=142307070911601, Pids="[0],[142307070911601],", Name="异常日志", Code="sys_log_mgr_ex_log", Type=1, Router="/exlog", Component="system/log/exlog", Application="system", OpenType=1, Visible="Y", Weight=1, Sort=100, Status=0},
                new SysMenu{Id=142307070911609, Pid=142307070911608, Pids="[0],[142307070911601],[142307070911608],", Name="异常日志查询", Code="sys_log_mgr_ex_log_page", Type=2, Permission="sysExLog:page", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },
                new SysMenu{Id=142307070911610, Pid=142307070911608, Pids="[0],[142307070911601],[142307070911608],", Name="异常日志清空", Code="sys_log_mgr_ex_log_delete", Type=2, Permission="sysExLog:delete", Application="system", OpenType=0, Visible="Y", Weight=1, Sort=100, Status=0 },


            };
        }
    }
}
