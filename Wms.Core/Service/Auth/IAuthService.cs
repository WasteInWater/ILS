using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Wms.Core.Service
{
    public interface IAuthService
    {
        Task<LoginOutput> GetLoginUserAsync();
        string LoginAsync([Required] LoginInput input);
        Task LogoutAsync();
    }
}