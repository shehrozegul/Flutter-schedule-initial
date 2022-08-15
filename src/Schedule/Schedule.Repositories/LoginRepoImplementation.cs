using Microsoft.AspNetCore.Identity;
using Schedule.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

using System.Threading.Tasks;

namespace Schedule.Repositories
{
    public class LoginRepoImplementation : ILoginInterface
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginRepoImplementation(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email,
                                   model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public IEnumerable<IdentityUser> Logout()
        {
            return null;
        }
       

        public async Task< bool> Register(RegisterViewModel model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var man=await  _userManager.CreateAsync(user, model.Password);
            if (man.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent:true);
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
