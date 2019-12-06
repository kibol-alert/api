using Kibol_Alert.Database;
using Kibol_Alert.Models;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Services
{
    public class ClubService : BaseService, IClubService
    {
        public ClubService(Kibol_AlertContext context) : base(context)
        {
        }

        public async Task<Response> AddClub(ClubRequest request)
        {
            var club = new Club()
            {
                Name = request.Name,
                League = request.League,
                LogoUri = request.LogoUri
            };

            await Context.Clubs.AddAsync(club);
            await Context.SaveChangesAsync();
            return new SuccessResponse<bool>(true);
        }

        //Do edycji
        public async Task<Response> AddRelation(ClubRelationRequest request)
        {
            var clubRelation = new ClubRelation()
            {
                FirstClubId = request.FirstClub.Id,
                FirstClub = request.FirstClub,
                SecondClubId = request.SecondClub.Id,
                SecondClub = request.SecondClub
            };

            await Context.ClubRelations.AddAsync(clubRelation);
            await Context.SaveChangesAsync();

            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> DeleteClub(int id)
        {
            var club = await Context.Clubs.FindAsync(id);
            if (club == null)
            {
                return new ErrorResponse("Club not found!");
            }
            Context.Clubs.Remove(club);
            await Context.SaveChangesAsync();
            
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> DeleteRelation(int id)
        {
            var clubRelation = await Context.ClubRelations.FindAsync(id);
            if (clubRelation == null)
            {
                return new ErrorResponse("Relation not found!");
            }
            Context.ClubRelations.Remove(clubRelation);
            await Context.SaveChangesAsync();
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> EditClub(int id, ClubRequest request)
        {
            var club = await Context.Clubs.FindAsync(id);

            if (club == null)
            {
                return new ErrorResponse("Club not found!");
            }

            club.Name = request.Name;
            club.League = request.League;
            club.LogoUri = request.LogoUri;

            Context.Clubs.Update(club);
            await Context.SaveChangesAsync();
            return new SuccessResponse<ClubVM>(true);
        }

        public async Task<Response> GetClub(int id)
        {
            /*
            var club = await Context.Clubs
                .Include(i => i.RelationsWith)
                .Include(i => i.InRelationsWith)
                .Include(i => i.Fans)
                .FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == id);

            var clubVm = new ClubVM()
            {
                Id = club.Id,
                Name = club.Name,
                League = club.League,
                LogoUri = club.LogoUri,
                ClubRelations = club.RelationsWith,
                InRelationsWith = club.InRelationsWith,

                Fans = club.Fans.Select(row => new UserVM()
                {
                    UserId = row.Club.Fans.
                    UserName = row.User.UserName,
                    AvatarUrl = row.User.AvatarUrl
                }).ToListAsync()
            };

            return new SuccessResponse<bool>(true);
            */
            throw new NotImplementedException();
        }

        public Task<Response> GetClubs(int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}