using Kibol_Alert.Models;
using Kibol_Alert.Requests;
using Kibol_Alert.Services;
using Kibol_Alert.Services.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace Kibol_Alert.Tests
{
    public class BrawlServiceTest
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly IBrawlService _brawlService;
        private readonly ILoggerService _logger;

        public BrawlServiceTest()
        {
            _contextBuilder = new ContextBuilder();
            _brawlService = new BrawlService(_contextBuilder.Context, _logger);
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
                    new DateTime(2020,01,01,12,00,00),
                    new Location(123456.0f, 987654.0f)
                }
            };
    }
}