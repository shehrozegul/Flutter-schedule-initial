using Microsoft.AspNetCore.Identity;
using Schedule.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedule.Repositories
{
    public interface ILoginInterface
    {
        Task<bool> Login(LoginViewModel model);
        IEnumerable<IdentityUser> Logout();
       Task<bool >Register(RegisterViewModel model);
    }
}