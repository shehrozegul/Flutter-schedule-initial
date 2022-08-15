using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Schedule.Repositories;
using Schedule.ViewModels;

namespace Schedule.MainApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoginInterface _loginInterface;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public HomeController(SignInManager<IdentityUser> signInManager,
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager,ILoginInterface loginInterface)
        {
            _userManager = userManager;
            _loginInterface = loginInterface;
            _signInManager = signInManager;
            _logger = logger;
        }

       

        
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            

            if (ModelState.IsValid)
            {
              var response=  await _loginInterface.Login(model);
                if (response==true)
                {
                    return Ok(200);
                }
                else
                {
                    return Ok(201);
                }
                
            }
            else
            {
                return Ok(400);
            }

            // If we got this far, something failed, redisplay form
            
        }
        [Route("logout")]
        [HttpPost]
        public async Task<IActionResult> LogoutAsync([FromBody] LoginViewModel model)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            
                
          
                return Ok();
            
        }
        
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
           
            if (ModelState.IsValid)
            {
               var response= await _loginInterface.Register(model);
                if (response==true)
                {
                    return Ok(200);
                }
                else
                {
                    return Ok(201);
                }
                
            }
            else
            {
                return Ok(400);
            }

            // If we got this far, something failed, redisplay form
            //return RedirectToPage("/");
        }
        [Route("forgetpassword")]
        public IActionResult ForgetPassword()
        {
            return Ok();
        }

    }
}
