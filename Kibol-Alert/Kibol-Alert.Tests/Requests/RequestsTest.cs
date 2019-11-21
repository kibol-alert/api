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
        
        //Then
        }
        
    }
}