using Microsoft.EntityFrameworkCore;
using Kibol_Alert.Database;
using Kibol_Alert.Models;
using Kibol_Alert.Requests;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.Services.ServiceResponses;
using Kibol_Alert.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Services
{/*
    public class ClubService : BaseService, IClubService
    {
        public ClubService(Kibol_AlertContext context) : base(context)
        {
        }

        async Task<ServiceResponse<IEnumerable<ClubVM>>> GetClubs(int skip, int take)
        {
            var clubs = await Context.Clubs
                .OrderByDescending(row => row)
                .Skip(skip)
                .Take(take)
                .Include(i => i.ClubRelations)
                .Include(i => i.Fans)
                .Select(row => new ClubVM()
                {
                    Id = row.Id,
                    Name = row.Name,
                    League = row.League,
                    LogoUri = row.LogoUri,
                    ClubRelations =  row.ClubRelations.SelectMany(row => GetClubRelations())
                    {
                        FirtClub = row.ClubRelations.FirstClub,
                        SecondClub = row.ClubRelations.SecondClub,
                    }).ToList(),
                    Fans = row.Fans
                });
            .ToListAsync();
            return ServiceResponse<IEnumerable<ClubVM>>.Ok(clubs);
        }
        Task<ServiceResponse<IEnumerable<ClubVM>>> GetClub(int id)
        {
            throw new NotImplementedException();
        }
        async Task<ServiceResponse<IEnumerable<ClubVM>>> AddClub(string name, string logoUri)
        {
            throw new NotImplementedException();
        }
        async Task<ServiceResponse<IEnumerable<ClubVM>>> DeleteClub(int id)
        {
            throw new NotImplementedException();
        }
        async Task<ServiceResponse<IEnumerable<ClubVM>>> EditClub(int id, string name, string logoUri)
        {
            throw new NotImplementedException();
        }
        async Task<ServiceResponse<IEnumerable<ClubVM>>> AddRelation(ClubRelation relation)
        {
            throw new NotImplementedException();
        }
        async Task<ServiceResponse<IEnumerable<ClubVM>>> DeleteRelation(ClubRelation relation)
        {
            throw new NotImplementedException();
        }
    }
    */
}