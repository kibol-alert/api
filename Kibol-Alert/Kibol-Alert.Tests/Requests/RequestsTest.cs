using Xunit;
using Kibol_Alert.Requests;
namespace Kibol_Alert.Tests.Requests
{
    public class RequestsTest
    {
        [Fact]
        public void LoginRequest()
        {
        //Given
        var input_login = new LoginRequest("admin@admin.pl", "admin", "dupa123");
        //When
        Assert.Equal("admin@admin.eu", input_login.Email);
        Assert.Equal("admin",input_login.UserName);
        Assert.Equal("pass", input_login.Password);
        
        //Then
        }
        
    }
}