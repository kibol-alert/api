using Kibol_Alert.Models;
using Kibol_Alert.ViewModels;
using Kibol_Alert.Services.ServiceResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kibol_Alert.Requests;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IAuthenticationService
    {
        ServiceResponse<bool> Register(RegisterRequest request);

        ServiceResponse<JwtToken> Login(LoginRequest request);

        ServiceResponse<bool> Logout();
    }
}
