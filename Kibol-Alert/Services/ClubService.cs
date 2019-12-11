using Kibol_Alert.Database;
using Kibol_Alert.Models;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<Response> AddRelation(ClubRelationRequest request)
        {
            var clubRelation = new ClubRelation()
            {
                FirstClubId = request.FirstClubId,
                SecondClubId = request.SecondClubId,
            };

            await Context.ClubRelations.AddAsync(clubRelation);
            await Context.SaveChangesAsync();

            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> DeleteClub(int id)
        {
            var club = await Context.Clubs.FirstOrDefaultAsync(i => i.Id == id);
            if (club == null)
            {
                return new ErrorResponse("Club not found!");
            }
            club.IsDeleted = true;
            await Context.SaveChangesAsync();
            
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> DeleteRelation(int id)
        {
            var clubRelation = await Context.ClubRelations.FirstOrDefaultAsync(i => i.FirstClub.Id == id);
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
            var club = await Context.Clubs.FirstOrDefaultAsync(i => i.Id == id);

            if (club == null)
            {
                return new ErrorResponse("Club not found!");
            }

            club.Name = request.Name;
            club.League = request.League;
            club.LogoUri = request.LogoUri;

            Context.Clubs.Update(club);
            await Context.SaveChangesAsync();
            return new SuccessResponse<ClubVM>();
        }

        public async Task<Response> GetClub(int id)
        {

            var club = await Context.Clubs
                .Include(i => i.RelationsWith)
                .Include(i => i.InRelationsWith)
                .Include(i => i.Fans)
                .FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == id);

            var clubDto = new ClubVM()
            {
                Id = club.Id,
                Name = club.Name,
                League = club.League,
                LogoUri = club.LogoUri,

                ClubRelations = club.RelationsWith.Select(row => new ClubRelationVM()
                { 
                    FirstClubId = row.FirstClubId,
                }) .ToList(),

                /*
                InRelationsWith = club.InRelationsWith.Select(row => new ClubRelationVM()
                {
                    SecondClubId = row.SecondClubId,
                }).ToList(),
                */

                Fans = club.Fans.Select(row => new MemberVM()
                {
                    MemberId = row.Id,
                    Name = row.UserName,
                }).ToList(),
            };

            return new SuccessResponse<ClubVM>();
        }

        public async Task<Response> GetClubs(int skip, int take)
        {
            var clubs = await Context.Clubs
                .Where(i => !i.IsDeleted)
                .OrderByDescending(row => row)
                .Skip(skip)
                .Take(take)
                .Include(i => i.RelationsWith)
                .Include(i => i.InRelationsWith)
                .Include(i => i.Fans)
                .Select(row => new ClubVM()
                {
                    Id = row.Id,
                    Name = row.Name,
                    League = row.League,
                    LogoUri = row.LogoUri,
                    ClubRelations = row.RelationsWith.Select(row => new ClubRelationVM()
                    {
                        FirstClubId = row.FirstClubId,
                    }).ToList(),

                    /*
                    InRelationsWith = row.InRelationsWith.Select(row => new ClubRelationVM()
                    {
                        SecondClubId = row.SecondClubId,
                    }).ToList(),
                    */

                    Fans = row.Fans.Select(row => new MemberVM()
                    {
                        MemberId = row.Id,
                        Name = row.UserName,
                    }).ToList(),
                }).ToListAsync();

            return new SuccessResponse<List<ClubVM>>();
        }
    }
}