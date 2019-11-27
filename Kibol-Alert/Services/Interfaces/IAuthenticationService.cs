using Kibol_Alert.Models;
using System.Threading.Tasks;
using Kibol_Alert.Requests;
using AutoWrapper.Wrappers;
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
