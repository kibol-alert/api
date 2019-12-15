using Kibol_Alert.Database;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;
using Kibol_Alert.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Services
{
    public class BrawlService : BaseService, IBrawlService
    {
        public BrawlService(Kibol_AlertContext context) : base(context)
        {
        }

        public Task<Response> AddBrawl(BrawlRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteBrawl(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> EditBrawl(int id, BrawlRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetBrawl(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetBrawls(int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}
