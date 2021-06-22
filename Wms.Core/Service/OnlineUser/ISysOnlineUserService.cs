using System.Threading.Tasks;

namespace Wms.Core.Service
{
    public interface ISysOnlineUserService
    {
        Task<dynamic> List();
    }
}