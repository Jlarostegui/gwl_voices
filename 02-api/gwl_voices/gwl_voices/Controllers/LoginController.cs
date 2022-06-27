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
            
            if (user !=  null && user.Password == login.password)
            {
                string token = _LoginService.GenerateToken(user);
                user.token = token;
                return Ok(user);
            }
            else
                return Unauthorized();
            
        }



        //[Route("api/[controller]/")]
        //[HttpPost]
        
        //public IActionResult VerifyToken(string token)
        //{
            
        //    bool valid = _LoginService.ValidateToken(token);
        //    if(valid)
        //    {
        //        return Ok(true);
        //    }
        //    else
        //    {
        //        return Unauthorized(new JsonResult(new { message = "token invalido" }) { StatusCode = StatusCodes.Status401Unauthorized });
        //    }

        //}


      





    }
}
