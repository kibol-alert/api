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
                Location = request.Location
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
            var brawl = new Brawl()
            {
                FirstClubId = request.FirstClubId,
                SecondClubId = request.SecondClubId,
                Date = request.Date,
                Location = request.Location
            };
            Context.Brawls.Update(brawl);
            await Context.SaveChangesAsync();
            return new SuccessResponse<BrawlVM>();
        }

        public Task<Response> GetBrawl(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetBrawls(int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}
