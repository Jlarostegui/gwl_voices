using gwl_voices.Application.Contracts.Services;
using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.login;

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


        [HttpPost]
        public IActionResult Login(LoginRequest login)
        {
            var user = _LoginService.login(login);
            string token = _LoginService.GenerateToken(user.Name);
            if (user.Password == login.password)
                return Ok(token);
            else
                return Unauthorized();
            
        }




     
    }
}
