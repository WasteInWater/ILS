using System.Threading.Tasks;

namespace Wms.Core.Service
{
    public interface IMachineService
    {
        Task<dynamic> GetMachineBaseInfo();
        Task<dynamic> GetMachineNetWorkInfo();
        Task<dynamic> GetMachineUseInfo();
    }
}