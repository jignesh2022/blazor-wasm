using BlazorProject.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public interface IUserRepository
    {
        Task<User> GetUser(int userid);
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser(User user);
        Task DeleteUser(int userid);

        /// <summary>
        /// returns token if valid    
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<string> Login(string email, string password);

    }
}
