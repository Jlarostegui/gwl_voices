using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace gwl_voices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : Controller
    {


        private IUserService _userService;

        public usersController(IUserService userService)
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

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            UserResponse? user = _userService.GetUserById(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        public IActionResult AddUser(UserRequest user)
        {
            UserResponse newUser = _userService.AddUser(user);

            return Ok(newUser);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser(int id)
        {
            bool result = _userService.DeleteUser(id);

            if (result)
            {
                return NoContent();

            }
            else
            {
                return BadRequest("El usuario que desea borrar no existe.");
            }

        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser(UserUpdateRequest user, int id)
        {
            UserResponse userUpdated = _userService.UpdateUser(user, id);
            return Ok(userUpdated);
        }
    }
}
