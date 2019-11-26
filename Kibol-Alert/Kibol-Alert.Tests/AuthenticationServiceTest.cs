using System;
using Xunit;
using Kibol_Alert.Requests;
using Kibol_Alert.Database;
using Kibol_Alert.Models;

namespace Kibol_Alert.Tests
{
    public class AuthenticationServiceTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly FakeSignInManager _signInManager;
        private readonly FakeUserManager _userManager;
        public AuthenticationServiceTest()
        {
            _contextBuilder = new ContextBuilder();
            _signInManager = new FakeSignInManager();
            _userManager = new FakeUserManager();

        }
        [Theory]
        [InlineData("user","password123.","email",true)]
        public async void RegisterTest(string username, string password, string email, bool excepted)
        {
            var user = new User()
            {
                Email = email,
                UserName = username,
            };
            var result = await _userManager.CreateAsync(user, password);

            Assert.Equal(result.Succeeded, excepted);

        }
        [Theory]
        [InlineData("user", "Password123.", false)]
        public async void LoginTest(string username, string password, bool excepted)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
            Assert.Equal(result.Succeeded, excepted);
        }
        [Fact]
        public void LogoutTest()
        {
            
        }
    }
}
