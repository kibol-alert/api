using Kibol_Alert.Database;
using Kibol_Alert.Models;
using Kibol_Alert.Requests;
using Kibol_Alert.Responses;
using Kibol_Alert.Services.Interfaces;
using Kibol_Alert.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kibol_Alert.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(Kibol_AlertContext context, ILoggerService logger) : base(context, logger)
        {
        }

        public async Task<Response> BanUser(string id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(i => i.Id == id && !i.IsBanned);
            if (user == null)
            {
                return new ErrorResponse("Użytkownika nie znaleziono lub już zbanowany!");
            }
            user.IsBanned = true;
            Context.Users.Update(user);
            await Context.SaveChangesAsync();
            AddLog($"Zbanowano użytkownika {user.UserName}, id: {user.Id}");
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> UnbanUser(string id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(i => i.Id == id && i.IsBanned);
            if (user == null)
            {
                return new ErrorResponse("Użytkownika nie znaleziono lub już odbanowany!");
            }
            user.IsBanned = false;
            Context.Users.Update(user);
            await Context.SaveChangesAsync();
            AddLog($"Odbanowano użytkownika {user.UserName}, id: {user.Id}");
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> DeleteUser(string id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);
            if (user == null)
            {
                return new ErrorResponse("Użytkownika nie znaleziono lub już usunięty!");
            }
            user.IsDeleted = true;
            Context.Users.Update(user);
            await Context.SaveChangesAsync();
            AddLog($"Usunięto użytkownika {user.UserName}, id: {user.Id}");
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> GiveAdmin(string id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(i => i.Id == id && !i.IsAdmin);
            if (user == null)
            {
                return new ErrorResponse("Użytkownika nie znaleziono lub już jest adminem!");
            }
            user.IsDeleted = true;
            Context.Users.Update(user);
            await Context.SaveChangesAsync();
            AddLog($"Nadano uprawnienia admina użytkownikowi {user.UserName}, id: {user.Id}");
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> TakeAdmin(string id)
        {
            var user = await Context.Users.FirstOrDefaultAsync(i => i.Id == id && i.IsAdmin);
            if (user == null)
            {
                return new ErrorResponse("Użytkownika nie znaleziono lub nie jest adminem!");
            }
            user.IsDeleted = false;
            Context.Users.Update(user);
            await Context.SaveChangesAsync();
            AddLog($"Zabrano uprawnienia admina użytkownikowi {user.UserName}, id: {user.Id}");
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> EditUser(string id, UserRequest request)
        {
            var user = await Context.Users.FirstOrDefaultAsync(i => i.Id == id);
            if (user == null)
            {
                return new ErrorResponse("Użytkownika nie znaleziono!");
            }
            user.ClubId = request.ClubId;
            Context.Users.Update(user);
            await Context.SaveChangesAsync();
            AddLog($"Edytowano użytkownika {user.UserName}, id: {user.Id}");
            return new SuccessResponse<bool>(true);
        }

        public async Task<Response> GetUser(string id)
        {
            var user = await Context.Users
                .Include(i => i.Club)
                .FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == id);

            var userDto = new UserVM()
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Club = new ClubBasicVM
                {
                    Id = user.Club.Id,
                    Name = user.Club.Name,
                    League = user.Club.League,
                    LogoUri = user.Club.LogoUri,
                    City = user.Club.City,
                    IsDeleted = user.IsDeleted
                },
                IsBanned = user.IsBanned,
                IsAdmin = user.IsAdmin
            };

            return new SuccessResponse<UserVM>(userDto);
        }

        public async Task<Response> GetUsers(int skip, int take)
        {
            var users = await Context.Users
                .Where(i => !i.IsDeleted)
                .OrderByDescending(row => row)
                .Skip(skip)
                .Take(take)
                .Include(row => row.Club)
                .Select(row => new UserVM()
                {
                    UserId = row.Id,
                    UserName = row.UserName,
                    Email = row.Email,
                    Club = new ClubBasicVM
                    {
                        Id = row.Club.Id,
                        Name = row.Club.Name,
                        League = row.Club.League,
                        LogoUri = row.Club.LogoUri,
                        City = row.Club.City,
                        IsDeleted = row.IsDeleted
                    },
                    IsBanned = row.IsBanned,
                    IsAdmin = row.IsAdmin
                }).ToListAsync();

            return new SuccessResponse<List<UserVM>>(users);
        }

        public async Task<Response> GetLogs()
        {
            var logs = await Context.Logs
                .OrderByDescending(row => row)
                .ToListAsync();

            return new SuccessResponse<List<Log>>(logs);
        }
    }
}