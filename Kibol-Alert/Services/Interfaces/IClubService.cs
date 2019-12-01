using Kibol_Alert.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kibol_Alert.Requests;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IClubService
    {
        public Task<IEnumerable<ClubVM>> GetClubs(int skip, int take);
        public Task<ClubVM> GetClub(int id);
        public Task<bool> AddClub(string name, string logoUri);
        public Task<bool> DeleteClub(int id);
        public Task<bool> EditClub(int id, string name, string logoUri);
        public Task<bool> AddRelation(ClubRelationRequest request);
        public Task<bool> DeleteRelation(ClubRelationRequest request);
    }
}
