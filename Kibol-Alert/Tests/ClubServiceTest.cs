using Kibol_Alert.Models;
using Kibol_Alert.Requests;
using Kibol_Alert.Services;
using Kibol_Alert.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Kibol_Alert.Tests
{
    public class ClubServiceTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly IClubService _clubService;
        private readonly ILoggerService _logger;

        public ClubServiceTest()
        {
            _contextBuilder = new ContextBuilder();
            _clubService = new ClubService(_contextBuilder.Context, _logger);
        }

        [Theory]
        [MemberData(nameof(DataForClubTest))]
        public async void AddClubTest(string name, string league, string logo)
        {
            var request = new ClubRequest()
            {
                Name = name,
                League = league,
                LogoUri = logo
            };

            var result = await _clubService.AddClub(request);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForChantTest))]
        public async void AddChantTest(string lyrics)
        {
            var request = new ClubChantRequest()
            {
                Lyrics = lyrics
            };

            var result = await _clubService.AddChant(request);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForEditChantTest))]
        public async void EditChantTest(string lyrics, int id, string lyrics2)
        {
            var request1 = new ClubChantRequest()
            {
                Lyrics = lyrics
            };
            var request2 = new ClubChantRequest()
            {
                Lyrics = lyrics2
            };

            var fakeChant = await _clubService.AddChant(request1);
            var fODChant = await _contextBuilder.Context.Chants.FirstOrDefaultAsync(i => i.Id == id);
            var result = await _clubService.EditChant(fODChant.Id, request2);

            Assert.True(result.Success);
        }

        public static IEnumerable<object[]> DataForClubTest =>
            new List<object[]>
            {
                new object[]{
                    "ClubTest",
                    "LeagueTest",
                    "LogoTest"
                }
            };
        public static IEnumerable<object[]> DataForChantTest =>
            new List<object[]>
            {
                new object[]{
                    "Chant lyrics test: Arka Gdynia..."
                }
            };
        public static IEnumerable<object[]> DataForEditChantTest =>
            new List<object[]>
            {
                new object[]{
                    "Chant lyrics test: Arka Gdynia...",
                    1,
                    "Chant lyrics test: Miedź Legnica aż po życia kres!"
                }
            };
    }
}
