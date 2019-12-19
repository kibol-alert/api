using System.Threading.Tasks;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Response> Register(RegisterRequest request);
        Task<Response> Login(LoginRequest request);
        Task<Response> Logout();
    }
}
