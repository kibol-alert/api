using Kibol_Alert.Services.ServiceResponses;
using Kibol_Alert.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Kibol_Alert.Requests;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IClubService
    {
        public Task<ServiceResponse<IEnumerable<ClubVM>>> GetClubs(int skip, int take);
        public Task<ServiceResponse<ClubVM>> GetClub(int id);
        public Task<ServiceResponse<bool>> AddClub(string name, string logoUri);
        public Task<ServiceResponse<bool>> DeleteClub(int id);
        public Task<ServiceResponse<bool>> EditClub(int id, string name, string logoUri);
        public Task<ServiceResponse<bool>> AddRelation(ClubRelationRequest request);
        public Task<ServiceResponse<bool>> DeleteRelation(ClubRelationRequest request);
    }
}
