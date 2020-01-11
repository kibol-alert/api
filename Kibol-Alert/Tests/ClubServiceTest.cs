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
        [MemberData(nameof(DataForClubTest))]
        public async void DeleteClubTest(string name, string league, string logo)
        {
            var request = new ClubRequest()
            {
                Name = name,
                League = league,
                LogoUri = logo
            };

            var fakeClub = await _clubService.AddClub(request);
            var fODClub = await _contextBuilder.Context.Clubs.FirstOrDefaultAsync(i => i.Name == name);
            var result = await _clubService.DeleteClub(fODClub.Id);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForEditClubTest))]
        public async void EditClubTest(string name, string league, string logo, string nameEdit, string leagueEdit, string logoEdit)
        {
            var request1 = new ClubRequest()
            {
                Name = name,
                League = league,
                LogoUri = logo
            };
            var request2 = new ClubRequest()
            {
                Name = nameEdit,
                League = leagueEdit,
                LogoUri = logoEdit
            };

            var fakeClub = await _clubService.AddClub(request1);
            var fODClub = await _contextBuilder.Context.Clubs.FirstOrDefaultAsync(i => i.Name == name);
            var result = await _clubService.EditClub(fODClub.Id, request2);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForClubTest))]
        public async void GetClubTest(string name, string league, string logo)
        {
            var request = new ClubRequest()
            {
                Name = name,
                League = league,
                LogoUri = logo
            };

            var fakeClub = await _clubService.AddClub(request);
            var fODClub = await _contextBuilder.Context.Clubs.FirstOrDefaultAsync(i => i.Name == name);
            var result = await _clubService.GetClub(fODClub.Id);

            Assert.True(result.Success);
        }
        [Theory]
        [MemberData(nameof(DataForGetClubsTest))]
        public async void GetClubsTest(string name, string league, string logo, string name2, string league2, string logo2, int skip, int take)
        {
            var request1 = new ClubRequest()
            {
                Name = name,
                League = league,
                LogoUri = logo
            };

            var request2 = new ClubRequest()
            {
                Name = name2,
                League = league2,
                LogoUri = logo2
            };

            var fakeClub = await _clubService.AddClub(request1);
            var fakeClub2 = await _clubService.AddClub(request2);
            var result = await _clubService.GetClubs(skip, take);

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

        [Theory]
        [MemberData(nameof(DataForChantTest))]
        public async void DeleteChantTest(string lyrics)
        {
            var request = new ClubChantRequest()
            {
                Lyrics = lyrics
            };

            var fakeChant = await _clubService.AddChant(request);
            var fODChant = await _contextBuilder.Context.Chants.FirstOrDefaultAsync(i => i.Lyrics == lyrics);
            var result = await _clubService.DeleteChant(fODChant.Id);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForRelationTest))]
        public async void AddRelationTest(int firstClubId, int secondClubId, RelationType relation)
        {
            var request = new ClubRelationRequest()
            {
                FirstClubId = firstClubId,
                SecondClubId = secondClubId,
                Relation = relation
            };

            var result = await _clubService.AddRelation(request);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForRelationTest))]
        public async void DeleteRelationTest(int firstClubId, int secondClubId, RelationType relation)
        {
            var request = new ClubRelationRequest()
            {
                FirstClubId = firstClubId,
                SecondClubId = secondClubId,
                Relation = relation
            };

            var fakeRelation = await _clubService.AddRelation(request);
            var fODRelation = await _contextBuilder.Context.ClubRelations.FirstOrDefaultAsync(i => i.FirstClubId == firstClubId);
            var result = await _clubService.DeleteRelation(fODRelation.FirstClub.Id);

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
        public static IEnumerable<object[]> DataForEditClubTest =>
            new List<object[]>
            {
                new object[]{
                    "ClubTest",
                    "LeagueTest",
                    "LogoTest",
                    "ClubTestEdited",
                    "LeagueTestEdited",
                    "LogoTestEdited"
                }
            };
        public static IEnumerable<object[]> DataForGetClubsTest =>
            new List<object[]>
            {
                new object[]{
                    "ClubTest",
                    "LeagueTest",
                    "LogoTest",
                    "ClubTestEdited",
                    "LeagueTestEdited",
                    "LogoTestEdited",
                    0,
                    2
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
        public static IEnumerable<object[]> DataForRelationTest =>
            new List<object[]>
            {
                new object[]{
                    1,
                    2,
                    2
                }
            };
    }
}
