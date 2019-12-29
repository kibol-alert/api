using Xunit;
using Kibol_Alert.Requests;
using Kibol_Alert.Models;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.Services;
using System.Collections.Generic;
using System;

namespace Kibol_Alert.Tests
{
    public class BrawlServiceTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly IBrawlService _brawlService;

        public BrawlServiceTest()
        {
            _contextBuilder = new ContextBuilder();
            _brawlService = new BrawlService(_contextBuilder.Context);
        }

        [Theory]
        [MemberData(nameof(DataForBrawlTest))]
        public async void AddBrawlTest(string FirstClubName, string SecondClubName, DateTime date, Location location)
        {
            var request = new BrawlRequest()
            {
                FirstClubName = FirstClubName,
                SecondClubName = SecondClubName,
                Date = date,
                Location = location
            };

            var result = await _brawlService.AddBrawl(request);

            Assert.True(result.Success);
        }

        public static IEnumerable<object[]> DataForBrawlTest =>
            new List<object[]>
            {
                new object[]{
                    "FirstClubName1",
                    "FirstClubName2",
                    "202001011200",
                    ("123456", "987654")
                }
            };
    }
}
