using Kibol_Alert.Models;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IJwtHelper
    {
        JwtToken GenerateJwtToken(string UserName);
    }
}
