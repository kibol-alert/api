using System.Threading.Tasks;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Response> GetUsers(int skip, int take);
        public Task<Response> GetUser(string id);
        public Task<Response> DeleteUser(string id);
        public Task<Response> BanUser(string id);
        public Task<Response> UnbanUser(string id);
        public Task<Response> GiveAdmin(string id);
        public Task<Response> TakeAdmin(string id);
        public Task<Response> EditUser(string id, UserRequest request);
        public Task<Response> GetLogs();
    }
}
