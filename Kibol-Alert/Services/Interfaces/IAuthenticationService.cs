using Kibol_Alert.Models;
using System.Threading.Tasks;
using Kibol_Alert.Requests;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> Register(RegisterRequest request);

        Task<JwtToken> Login(LoginRequest request);

        Task<bool> Logout();
    }
}
