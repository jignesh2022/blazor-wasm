using BlazorProject.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Client.Services
{
    public interface IUserService
    {
        Task<string> Login(Login login);

        Task<string> Register(Register login);

        Task<bool> EmailExists(string email);
    }
}