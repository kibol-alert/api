
using Kibol_Alert.Database;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;
using Kibol_Alert.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Kibol_Alert.Services
{
    public class ClubService : BaseService, IClubService
    {
        public ClubService(Kibol_AlertContext context) : base(context)
        {
        }

        public Task<Response> AddClub(ClubRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response> AddRelation(ClubRelationRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteClub(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteRelation(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> EditClub(int id, ClubRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetClub(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetClubs(int skip, int take)
        {
            throw new NotImplementedException();
        }
    }

}