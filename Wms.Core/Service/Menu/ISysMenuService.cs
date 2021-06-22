using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wms.Core.Service
{
    public interface ISysMenuService
    {
        Task AddMenu(AddMenuInput input);
        Task<List<LayuiMenu>> ChangeAppMenu();
        Task DeleteMenu(DeleteMenuInput input);
        Task<List<LayuiMenu>> GetLoginMenusDesign(long userId, string appCode);
        Task<List<string>> GetLoginPermissionList(long userId);
        Task<dynamic> GetMenu(QueryMenuInput input);
        Task<dynamic> GetMenuList([FromQuery] MenuInput input);
        Task<dynamic> GetMenuTree([FromQuery] MenuInput input);
        Task<List<string>> GetUserMenuAppCodeList(long userId);
        Task<bool> HasMenu(string appCode);
        Task<dynamic> TreeForGrant([FromQuery] MenuInput input);
        Task UpdateMenu(UpdateMenuInput input);
    }
}