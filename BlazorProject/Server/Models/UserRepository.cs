using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext appDbContext;
        private readonly IConfiguration configuration;

        public UserRepository(AppDBContext _appDbContext, IConfiguration _configuration)
        {
            appDbContext = _appDbContext;
            configuration = _configuration;
        }
        public async Task<User> AddUser(User user)
        {            
            string salt = SecurityHelper.GenerateSalt(20);
            string pwdHashed = SecurityHelper.HashPassword(user.Password, salt, 100, 20);

            user.Password = pwdHashed;
            user.Salt = salt;
            user.Roles = "User";

            var result = await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteUser(int userid)
        {
            var result = await appDbContext.Users
                .FirstOrDefaultAsync(u => u.UserId == userid);

            if (result != null)
            {
                appDbContext.Users.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<User> GetUser(int userid)
        {
            return await appDbContext.Users
                    .FirstOrDefaultAsync(u => u.UserId == userid);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await appDbContext.Users
                    .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<string> Login(string email, string password)
        {
            string token = null;
            User user = await appDbContext.Users
                    .FirstOrDefaultAsync(u => u.Email == email);
            if(user == null)
            {
                return token;
            }
            string salt = user.Salt;
            string storedPwd = user.Password;

            string pwdHashed = SecurityHelper.HashPassword(password, salt, 100, 20); 

            //https://dev.to/1001binary/hashing-password-combining-with-salt-in-c-and-vb-net-2am9

            if (pwdHashed.Equals(storedPwd))
            {
                token =  Utility.GenerateAccessToken(user.UserId, user.Roles, 
                    user.FirstName + " " + user.LastName,
                    configuration.GetValue<string>("TOKEN_SECRET"));
                     
            }

            return token;
        }
    }
}
