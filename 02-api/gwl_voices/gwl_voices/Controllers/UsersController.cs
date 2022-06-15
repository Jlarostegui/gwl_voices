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
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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


        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers()
        {
            List<UserResponse> users = await _userService.GetAllUsers();
            if (users == null)
                return NoContent();
            else
                return Ok(users);

        }

        [HttpPost]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddUser(UserRequest user)
        {
            UserResponse newUser = _userService.AddUser(user);

            return Ok(newUser);
        }


        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateUser(UserUpdateRequest user, int id)
        {
            
            UserResponse userUpdated = _userService.UpdateUser(user, id);

            if (string.IsNullOrEmpty(userUpdated.Error))
                return Ok(userUpdated);
            else
                return BadRequest(userUpdated.Error);
        }
    }
}
