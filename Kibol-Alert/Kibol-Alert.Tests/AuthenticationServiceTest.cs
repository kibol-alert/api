using System;
using Xunit;
using Kibol_Alert.Requests;
using Kibol_Alert.Database;
using Kibol_Alert.Models;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.Services;
using Kibol_Alert.Helpers;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Kibol_Alert.Tests
{
    public class AuthenticationServiceTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly FakeSignInManager _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authorizationService;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly JwtHelper _jwtHelper;
        public AuthenticationServiceTest()
        {
            _contextBuilder = new ContextBuilder();
            _signInManager = new FakeSignInManager();
            _userManager = CreateUserManager("Server=tcp:kosa-czy-sztama.database.windows.net,1433;Initial Catalog=kosa-czy-sztama;Persist Security Info=False;User ID=kosa;Password=Qwer1234.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            _appSettings = Options.Create(new AppSettings(){ Secret = "SPECIALFORTESTS" });
            _jwtHelper = new JwtHelper(_appSettings, _contextBuilder.Context);
            _authorizationService = new AuthenticationService(_contextBuilder.Context, _signInManager, _userManager, _jwtHelper);

        }
        [Theory]
        [MemberData(nameof(DataForRegister))]
        public async void RegisterTest(string email, string username, string password, string confirmedPassword, int clubId)
        {
            var request = new RegisterRequest()
            {
                Email = email,
                UserName = username,
                Password = password,
                ConfirmedPassword = confirmedPassword,
                ClubId = clubId
            };

            var result = await _authorizationService.Register(request);

            Assert.True(result.Success);

        }
        public static IEnumerable<object[]> DataForRegister =>
            new List<object[]>
            {
                new object[]{ 
                    "test2@example.com",
                    "test",
                    "Test123.",
                    "Test123.",
                    1
                }
            };

        private static UserManager<User> CreateUserManager(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Kibol_AlertContext>().UseSqlServer(connectionString);
            var userStore = new UserStore<User>(
                   new Kibol_AlertContext(
                     optionsBuilder.Options
                 ));

            var identityOption = new IdentityOptions();
            identityOption.Password.RequiredLength = 8;
            identityOption.Password.RequireNonAlphanumeric = true;
            identityOption.Password.RequireDigit = true;
            identityOption.Password.RequireUppercase = true;

            var options = Options.Create(identityOption);
            var userValidators = new List<IUserValidator<User>>();

            var pwdValidators = new List<PasswordValidator<User>>();
            {
                new PasswordValidator<User>();
            };

            return new UserManager<User>(
                         userStore,
                         options,
                         new PasswordHasher<User>(),
                          userValidators,
                          pwdValidators,
                          new UpperInvariantLookupNormalizer(),
                          new IdentityErrorDescriber(),
                          null,
                          null);
        }
        [Theory]
        [MemberData(nameof(DataForLogin))]
        public async void LoginTest(string username, string password) {
            var request = new LoginRequest()
            {
                UserName = username,
                Password = password

            };

            var result = await _authorizationService.Login(request);

            Assert.True(result.Success);

        }

        public static IEnumerable<object[]> DataForLogin =>
            new List<object[]>
            {
                new object[]{ 
                    "test",
                    "Test123."
                }
            };


        [Fact]
        public void LogoutTest()
        {
            //Given

            //When

            //Then
        }
    }
}
