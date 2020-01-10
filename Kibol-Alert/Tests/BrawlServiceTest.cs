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
        [MemberData(nameof(DataForAddBrawlTest))]
        public async void AddBrawlTest(string FirstClubName, string SecondClubName, string date, float longitude, float latitude)
        {
            var request = new BrawlRequest()
            {
                FirstClubName = FirstClubName,
                SecondClubName = SecondClubName,
                Date = date,
                Longitude = longitude,
                Latitude = latitude
            };

            var result = await _brawlService.AddBrawl(request);

            Assert.True(result.Success);
        }
        public static IEnumerable<object[]> DataForAddBrawlTest =>
            new List<object[]>
            {
                new object[]{
                    "FirstClubName1",
                    "FirstClubName2",
                    "2020.01.01 12:00:00",
                    123456.0f, 
                    987654.0f
                }
            };

        [Theory]
        [MemberData(nameof(DataForDeletetBrawlTest))]
        public async void DeleteBrawlTest(string firstClubName, string secondClubName, string date, float longitude, float latitude, int id)
        {
            var request = new BrawlRequest()
            {
                FirstClubName = firstClubName,
                SecondClubName = secondClubName,
                Date = date,
                Longitude = longitude,
                Latitude = latitude
            };

            var fakeBrawl = await _brawlService.AddBrawl(request);
            var fODBrawl = await _contextBuilder.Context.Brawls.FirstOrDefaultAsync(i => i.Id == id);
            var result = await _brawlService.DeleteBrawl(fODBrawl.Id);

            Assert.True(result.Success);
        }
        public static IEnumerable<object[]> DataForDeletetBrawlTest =>
            new List<object[]>
            {
                new object[]{
                    "FirstClubName1",
                    "FirstClubName2",
                    "2020.01.01 12:00:00",
                    123456.0f, 
                    987654.0f,
                    1
                }
            };

        [Theory]
        [MemberData(nameof(DataForEditBrawlTest))]
        public async void EditBrawlTest(string firstClubName, string secondClubName, string date, float longitude, float latitude, int id, string firstClubNameEdit, string secondClubNameEdit, string dateEdit, float longitudeEdit, float latitudeEdit)
        {
            var request1 = new BrawlRequest()
            {
                FirstClubName = firstClubName,
                SecondClubName = secondClubName,
                Date = date,
                Longitude = longitude,
                Latitude = latitude
            };
            var request2 = new BrawlRequest()
            {
                FirstClubName = firstClubNameEdit,
                SecondClubName = secondClubNameEdit,
                Date = dateEdit,
                Longitude = longitudeEdit,
                Latitude = latitudeEdit
            };

            var fakeBrawl = await _brawlService.AddBrawl(request1);
            var fODBrawl = await _contextBuilder.Context.Brawls.FirstOrDefaultAsync(i => i.Id == id);
            var result = await _brawlService.EditBrawl(id, request2);

            Assert.True(result.Success);
        }
        public static IEnumerable<object[]> DataForEditBrawlTest =>
            new List<object[]>
            {
                new object[]{
                    "FirstClubName1",
                    "FirstClubName2",
                    "2020.01.01 12:00:00",
                    123456.7, 
                    987654.3f,
                    1,
                    "FirstClubName1Edited",
                    "FirstClubName2Edited",
                    "2137.01.01 12:00:00",
                    111111.1f, 
                    999999.9f
                }
            };

        [Theory]
        [MemberData(nameof(DataForDeletetBrawlTest))]
        public async void GetBrawlTest(string firstClubName, string secondClubName, string date, float longitude, float latitude, int id)
        {
            var request = new BrawlRequest()
            {
                FirstClubName = firstClubName,
                SecondClubName = secondClubName,
                Date = date,
                Longitude = longitude,
                Latitude = latitude
            };

            var fakeBrawl = await _brawlService.AddBrawl(request);
            var fODBrawl = await _contextBuilder.Context.Brawls.FirstOrDefaultAsync(i => i.Id == id);
            var result = await _brawlService.GetBrawl(fODBrawl.Id);

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(DataForGetBrawlsTest))]
        public async void GetBrawlsTest(string firstClubName, string secondClubName, string date, float longitude, float latitude, string firstClubName2, string secondClubName2, string date2, float longitude2, float latitude2, int skip, int take)
        {
            var request1 = new BrawlRequest()
            {
                FirstClubName = firstClubName,
                SecondClubName = secondClubName,
                Date = date,
                Longitude = longitude,
                Latitude = latitude
            };
            var request2 = new BrawlRequest()
            {
                FirstClubName = firstClubName2,
                SecondClubName = secondClubName2,
                Date = date2,
                Longitude = longitude2,
                Latitude = latitude2
            };

            var fakeBrawl = await _brawlService.AddBrawl(request1);
            var fakeBrawl2 = await _brawlService.AddBrawl(request2);
            var result = await _brawlService.GetBrawls(skip, take);

            Assert.True(result.Success);
        }
        public static IEnumerable<object[]> DataForGetBrawlsTest =>
            new List<object[]>
            {
                new object[]{
                    "FirstClubName1",
                    "FirstClubName2",
                    "2020.01.01 12:00:00",
                    123456.7,
                    987654.3f,
                    "FirstClubName1Edited",
                    "FirstClubName2Edited",
                    "2137.01.01 12:00:00",
                    111111.1f,
                    999999.9f,
                    0,
                    2
                }
            };
    }
}