using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatech.Application.EntitiesCQ.Autho.Interfaces
{
    public interface IAuthRepository
    {
       // Task<int> Register(User user, string password);
        Task<string> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
