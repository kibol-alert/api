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

        [Theory]
        [MemberData(nameof(DataForDeletetBrawlTest))]
        public async void DeleteBrawlTest(string FirstClubName, string SecondClubName, DateTime date, Location location, int id)
        {
            var request = new BrawlRequest()
            {
                FirstClubName = FirstClubName,
                SecondClubName = SecondClubName,
                Date = date,
                Location = location
            };

            var fakeBrawl = await _brawlService.AddBrawl(request);
            var fODBrawl = await _contextBuilder.Context.Brawls.FirstOrDefaultAsync(i => i.Id == id);
            var result = await _brawlService.DeleteBrawl(fODBrawl.Id);

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
        
        public static IEnumerable<object[]> DataForDeletetBrawlTest =>
            new List<object[]>
            {
                new object[]{
                    "FirstClubName1",
                    "FirstClubName2",
                    new DateTime(2020,01,01,12,00,00),
                    new Location(123456.0f, 987654.0f),
                    1
                }
            };
    }
}