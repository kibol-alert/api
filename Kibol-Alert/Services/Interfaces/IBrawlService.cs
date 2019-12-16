using Kibol_Alert.Requests;
using Kibol_Alert.Responses;
using System.Threading.Tasks;

namespace Kibol_Alert.Services.Interfaces
{
    public interface IBrawlService
    {
        public Task<Response> GetBrawls(int skip, int take);
        public Task<Response> GetBrawl(int id);
        public Task<Response> AddBrawl(BrawlRequest request);
        public Task<Response> DeleteBrawl(int id);
        public Task<Response> EditBrawl(int id, BrawlRequest request);
    }
}
