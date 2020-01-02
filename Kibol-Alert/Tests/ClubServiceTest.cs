using Kibol_Alert.Requests;
using Kibol_Alert.Services;
using Kibol_Alert.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        [MemberData(nameof(DataForAddClubTest))]
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
        public static IEnumerable<object[]> DataForAddClubTest =>
            new List<object[]>
            {
                new object[]{
                    "ClubTest",
                    "LeagueTest",
                    "LogoTest"
                }
            };

        [Theory]
        [MemberData(nameof(DataForEditClubTest))]
        public async void EditClubTest(string name1, string league1, string logo1, int id, string name2, string league2, string logo2)
        {
            var request1 = new ClubRequest()
            {
                Name = name1,
                League = league1,
                LogoUri = logo1
            };

            var request2 = new ClubRequest()
            {
                Name = name2,
                League = league2,
                LogoUri = logo2
            };

            var fakeClub = await _clubService.AddClub(request1);
            var fODClub = await _contextBuilder.Context.Clubs.FirstOrDefaultAsync(i => i.Id == id);
            var result = await _clubService.EditClub(fODClub.Id, request2);

            Assert.True(result.Success);
        }
        public static IEnumerable<object[]> DataForEditClubTest =>
            new List<object[]>
            {
                new object[]{
                    "ClubNameTest1",
                    "LeagueTest1",
                    "LogoTest1",
                    1,
                    "ClubNameTest2",
                    "LeagueTest2",
                    "LogoTest2"
                }
            };

        [Theory]
        [MemberData(nameof(DataForDeleteClubTest))]
        public async void DeleteClubTest(string name, string league, string logo, int id)
        {
            var request = new ClubRequest()
            {
                Name = name,
                League = league,
                LogoUri = logo
            };

            var fakeClub = await _clubService.AddClub(request);
            var fODClub = await _contextBuilder.Context.Clubs.FirstOrDefaultAsync(i => i.Id == id);
            var result = await _clubService.DeleteClub(fODClub.Id);

            Assert.True(result.Success);
        }
        public static IEnumerable<object[]> DataForDeleteClubTest =>
            new List<object[]>
            {
                new object[]{
                    "ClubTest",
                    "LeagueTest",
                    "LogoTest",
                    1
                }
            };

        [Theory]
        [MemberData(nameof(DataForAddChantTest))]
        public async void AddChantTest(string lyrics)
        {
            var request = new ClubChantRequest()
            {
                Lyrics = lyrics
            };

            var result = await _clubService.AddChant(request);

            Assert.True(result.Success);
        }
        public static IEnumerable<object[]> DataForAddChantTest =>
            new List<object[]>
            {
                new object[]{
                    "Chant lyrics test: Arka Gdynia..."
                }
            };

        [Theory]
        [MemberData(nameof(DataForEditChantTest))]
        public async void EditChantTest(string lyrics1, int id, string lyrics2)
        {
            var request1 = new ClubChantRequest()
            {
                Lyrics = lyrics1
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
        public static IEnumerable<object[]> DataForEditChantTest =>
            new List<object[]>
            {
                new object[]{
                    "Chant lyrics test: Arka Gdynia...",
                    1,
                    "Chant lyrics test: Miedź Legnica aż po życia kres!"
                }
            };

        [Theory]
        [MemberData(nameof(DataForDeleteChantTest))]
        public async void DeleteChantTest(string lyrics, int id)
        {
            var request1 = new ClubChantRequest()
            {
                Lyrics = lyrics
            };

            var fakeChant = await _clubService.AddChant(request1);
            var fODChant = await _contextBuilder.Context.Chants.FirstOrDefaultAsync(i => i.Id == id);
            var result = await _clubService.DeleteChant(fODChant.Id);

            Assert.True(result.Success);
        }
        public static IEnumerable<object[]> DataForDeleteChantTest =>
            new List<object[]>
            {
                new object[]{
                    "Chant lyrics test: Arka Gdynia...",
                    1
                }
            };

        [Theory]
        [MemberData(nameof(DataForAddRelationTest))]
        public async void AddRelationTest(int id1, int id2)
        {
            var request = new ClubRelationRequest()
            {
                FirstClubId = id1,
                SecondClubId = id2
            };

            var result = await _clubService.AddRelation(request);

            Assert.True(result.Success);
        }
        public static IEnumerable<object[]> DataForAddRelationTest =>
            new List<object[]>
            {
                new object[]{
                    1,
                    2
                }
            };

        [Theory]
        [MemberData(nameof(DataForDeleteRelationTest))]
        public async void DeleteRelationTest(int id1, int id2)
        {
            var request = new ClubRelationRequest()
            {
                FirstClubId = id1,
                SecondClubId = id2
            };

            var fakeRelation = await _clubService.AddRelation(request);
            var fODRelation = await _contextBuilder.Context.ClubRelations.FirstOrDefaultAsync(i => i.FirstClubId == id1);
            var result = await _clubService.DeleteRelation(fODRelation.FirstClubId);

            Assert.True(result.Success);
        }
        public static IEnumerable<object[]> DataForDeleteRelationTest =>
            new List<object[]>
            {
                new object[]{
                    1,
                    2
                }
            };
    }
}
