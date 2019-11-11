using Kibol_Alert.Models;
using Kibol_Alert.Services.ServiceResponses;
using System.Threading.Tasks;
using Kibol_Alert.Requests;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ServiceResponse<bool>> Register(RegisterRequest request);

        Task<ServiceResponse<JwtToken>> Login(LoginRequest request);

        Task<ServiceResponse<bool>> Logout();
    }
}
