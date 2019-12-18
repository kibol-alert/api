using System.Threading.Tasks;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Response> GetUsers(int skip, int take);
        public Task<Response> GetUser(int id);
        public Task<Response> DeleteUser(int id);
        public Task<Response> BanUser(int id);
        public Task<Response> UnbanUser(int id);
        public Task<Response> GiveAdmin(int id);
        public Task<Response> TakeAdmin(int id);
        public Task<Response> EditUser(int id, UserRequest request);
    }
}
