using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace gwl_voices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {


        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult GetUserByName(string name)
        {
            UserResponse? user = _userService.GetUserByName(name);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NoContent();
            }
        }


    }
}
