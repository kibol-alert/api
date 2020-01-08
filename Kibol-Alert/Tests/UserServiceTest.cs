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
    public class UserServiceTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly FakeSignInManager _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _authorizationService;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly JwtHelper _jwtHelper;
        private readonly ILoggerService _logger;
        private readonly IUserService _userService;

        public UserServiceTest()
        {
            _contextBuilder = new ContextBuilder();
            _contextBuilder = new ContextBuilder();
            _signInManager = new FakeSignInManager();
            _userManager = CreateUserManager();
            _appSettings = Options.Create(new AppSettings() { Secret = "SPECIALFORTESTS" });
            _jwtHelper = new JwtHelper(_appSettings, _contextBuilder.Context);
            _authorizationService = new AuthenticationService(_contextBuilder.Context, _signInManager, _userManager, _jwtHelper, _logger);
            _userService = new UserService(_contextBuilder.Context, _logger);
        }

        [Theory]
        [MemberData(nameof(DataForUserTest))]
        public async void BanUserTest(string email, string username, string password, string confirmedPassword, int clubId, string userId)
        {
            var request = new RegisterRequest()
            {
                Email = email,
                UserName = username,
                Password = password,
                ConfirmedPassword = confirmedPassword,
                ClubId = clubId
            };

            var fakeUser = await _authorizationService.Register(request);
            var fODUser = await _contextBuilder.Context.Users.FirstOrDefaultAsync(i => i.Id == userId);
            var result = await _userService.BanUser(fODUser.Id);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForUserTest))]
        public async void UnBanUserTest(string email, string username, string password, string confirmedPassword, int clubId, string userId)
        {
            var request = new RegisterRequest()
            {
                Email = email,
                UserName = username,
                Password = password,
                ConfirmedPassword = confirmedPassword,
                ClubId = clubId
            };

            var fakeUser = await _authorizationService.Register(request);
            var fODUser = await _contextBuilder.Context.Users.FirstOrDefaultAsync(i => i.Id == userId);
            var result = await _userService.UnbanUser(fODUser.Id);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForUserTest))]
        public async void DeleteUserTest(string email, string username, string password, string confirmedPassword, int clubId, string userId)
        {
            var request = new RegisterRequest()
            {
                Email = email,
                UserName = username,
                Password = password,
                ConfirmedPassword = confirmedPassword,
                ClubId = clubId
            };

            var fakeUser = await _authorizationService.Register(request);
            var fODUser = await _contextBuilder.Context.Users.FirstOrDefaultAsync(i => i.Id == userId);
            var result = await _userService.DeleteUser(fODUser.Id);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForUserTest))]
        public async void GiveAdminUserTest(string email, string username, string password, string confirmedPassword, int clubId, string userId)
        {
            var request = new RegisterRequest()
            {
                Email = email,
                UserName = username,
                Password = password,
                ConfirmedPassword = confirmedPassword,
                ClubId = clubId
            };

            var fakeUser = await _authorizationService.Register(request);
            var fODUser = await _contextBuilder.Context.Users.FirstOrDefaultAsync(i => i.Id == userId);
            var result = await _userService.GiveAdmin(fODUser.Id);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForUserTest))]
        public async void TakeAdminUserTest(string email, string username, string password, string confirmedPassword, int clubId, string userId)
        {
            var request = new RegisterRequest()
            {
                Email = email,
                UserName = username,
                Password = password,
                ConfirmedPassword = confirmedPassword,
                ClubId = clubId
            };

            var fakeUser = await _authorizationService.Register(request);
            var fODUser = await _contextBuilder.Context.Users.FirstOrDefaultAsync(i => i.Id == userId);
            var result = await _userService.TakeAdmin(fODUser.Id);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForEditUserTest))]
        public async void EditUserTest(string email1, string username1, string password1, string confirmedPassword1, int clubId1, string userId, int clubId2)
        {
            var request1 = new RegisterRequest()
            {
                Email = email1,
                UserName = username1,
                Password = password1,
                ConfirmedPassword = confirmedPassword1,
                ClubId = clubId1
            };
            var request2 = new UserRequest()
            {
                ClubId = clubId2
            };

            var fakeUser = await _authorizationService.Register(request1);
            var fODUser = await _contextBuilder.Context.Users.FirstOrDefaultAsync(i => i.Id == userId);
            var result = await _userService.EditUser(fODUser.Id, request2);

            Assert.True(result.Success);
        }
        public static IEnumerable<object[]> DataForEditUserTest =>
            new List<object[]>
            {
                new object[]{
                    "UserTest@example.com",
                    "Usertest654",
                    "Test123.",
                    "Test123.",
                    5,
                    "99",
                    6
                }
            };
        public static IEnumerable<object[]> DataForUserTest =>
            new List<object[]>
            {
                new object[]{
                    "UserTest@example.com",
                    "Usertest789",
                    "Test123.",
                    "Test123.",
                    5,
                    "125"
                }
            };


        private static UserManager<User> CreateUserManager()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Kibol_AlertContext>().UseInMemoryDatabase(databaseName: "Add_writes_to_database");
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
    }
}