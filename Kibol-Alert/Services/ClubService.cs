using Kibol_Alert.Database;
using Kibol_Alert.Models;
using Kibol_Alert.Services.ServiceResponses;
using Kibol_Alert.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Services
{
    public class ClubService : BaseService
    {
        public ClubService(Kibol_AlertContext context) : base(context)
        {
        }

        public async Task<ServiceResponse<IEnumerable<ClubVM>>> GetClubs(int skip, int take)
        {
            throw new NotImplementedException();
            //work in progress
        }
        public async Task<ServiceResponse<IEnumerable<ClubVM>>> GetClub(int id)
        {
            throw new NotImplementedException();
            //work in progress
        }
        public async Task<ServiceResponse<IEnumerable<ClubVM>>> AddClub(string name, string logoUri)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<IEnumerable<ClubVM>>> DeleteClub(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<IEnumerable<ClubVM>>> EditClub(int id, string name, string logoUri)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<IEnumerable<ClubVM>>> AddRelation(ClubRelations relation)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<IEnumerable<ClubVM>>> DeleteRelation(ClubRelations relation)
        {
            throw new NotImplementedException();
        }
    }
}
