using Kibol_Alert.Database;
using Kibol_Alert.Models;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(Kibol_AlertContext context) : base(context)
        {
        }

        public Task<Response> BanUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> EditUser(int id, UserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetUsers(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GiveAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> TakeAdmin(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UnbanUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
