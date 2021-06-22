using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wms.Core.Service
{
    public interface ISysUserDataScopeService
    {
        Task DeleteUserDataScopeListByOrgIdList(List<long> orgIdList);
        Task DeleteUserDataScopeListByUserId(long userId);
        Task<List<long>> GetUserDataScopeIdList(long userId);
        Task GrantData(UpdateUserInput input);
    }
}