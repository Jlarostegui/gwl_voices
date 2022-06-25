using gwl_voices.Application.Contracts.Services;
using gwl_voices.BusinessModels.Models.login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gwl_voices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {


        private ILoginService _LoginService;
        


        public LoginController(ILoginService loginService)
        {
               _LoginService = loginService;    

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginRequest login)
        {
            LoginResponse user = _LoginService.login(login);
            string token = _LoginService.GenerateToken(user);
            user.token = token;
            
            if (user.Password == login.password)
                return Ok(user);
            else
                return Unauthorized();
            
        }


      





    }
}
