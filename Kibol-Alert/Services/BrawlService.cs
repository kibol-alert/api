using Kibol_Alert.Database;
using Kibol_Alert.Models;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Services
{
    public class BrawlService : BaseService, IBrawlService
    {
        public BrawlService(Kibol_AlertContext context) : base(context)
        {
        }

        public async Task<Response> AddBrawl(BrawlRequest request)
        {
            var brawl = new Brawl()
            {
                FirstClubId = request.FirstClubId,
                SecondClubId = request.SecondClubId,
                Date = request.Date,
                Location = new Location()
                {
                    Latitude = request.Latitude,
                    Longitude = request.Longitude
                }
            };
            await Context.Brawls.AddAsync(brawl);
            await Context.SaveChangesAsync();
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> DeleteBrawl(int id)
        {
            var brawl = await Context.Brawls.FirstOrDefaultAsync(i => i.Id == id);
            if (brawl == null)
            {
                return new ErrorResponse("Brawl not found!");
            }
            Context.Brawls.Remove(brawl);
            await Context.SaveChangesAsync();
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> EditBrawl(int id, BrawlRequest request)
        {
            var brawl = await Context.Brawls.FirstOrDefaultAsync(i => i.Id == id);
            if (brawl == null)
            {
                return new ErrorResponse("Brawl not found!");
            }

            brawl.FirstClubId = request.FirstClubId;
            brawl.SecondClubId = request.SecondClubId;
            brawl.Date = request.Date;
            brawl.Location = new Location()
            {
                Latitude = request.Latitude,
                Longitude = request.Longitude
            };
            
            Context.Brawls.Update(brawl);
            await Context.SaveChangesAsync();
            return new SuccessResponse<BrawlVM>();
        }

        public async Task<Response> GetBrawl(int id)
        {
            var brawl = await Context.Brawls
                .Include(i => i.FirstClub)
                .Include(i => i.SecondClub)
                .Include(i => i.Location)
                .FirstOrDefaultAsync(i => i.Id == id);

            var bralwDto = new BrawlVM()
            {
                Id = brawl.Id,
                FirstClubId = brawl.FirstClubId,
                SecondClubId = brawl.SecondClubId,
                Date = brawl.Date,
                Location = brawl.Location
            };

            return new SuccessResponse<BrawlVM>();
        }

        public async Task<Response> GetBrawls(int skip, int take)
        {
            var brawls = await Context.Brawls
                .OrderByDescending(row => row)
                .Skip(skip)
                .Take(take)
                .Include(i => i.FirstClub)
                .Include(i => i.SecondClub)
                .Include(i => i.Location)
                .Select(row => new BrawlVM()
                {
                    Id = row.Id,
                    FirstClubId = row.FirstClubId,
                    SecondClubId = row.SecondClubId,
                    Date = row.Date,
                    Location = row.Location
                }).ToListAsync();

            return new SuccessResponse<List<BrawlVM>>();
        }
    }
}
