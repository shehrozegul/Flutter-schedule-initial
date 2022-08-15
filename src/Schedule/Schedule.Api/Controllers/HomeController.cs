using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Schedule.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {

        }
        [Route("login")]
        public IActionResult Login()
        {
            return Ok(200);
        }
        [Route("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
        [Route("register")]
        public IActionResult Register()
        {
            return Ok();
        }
        [Route("forgetpassword")]
        public IActionResult ForgetPassword()
        {
            return Ok();
        }

    }
}
