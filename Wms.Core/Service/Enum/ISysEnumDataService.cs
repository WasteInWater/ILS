using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Wms.Core.Service
{
    public interface ISysEnumDataService
    {
        Task<dynamic> GetEnumDataList([FromQuery] EnumDataInput input);
        Task<dynamic> GetEnumDataListByField([FromQuery] QueryEnumDataInput input);
    }
}