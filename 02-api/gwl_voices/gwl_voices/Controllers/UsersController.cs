using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.User;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [Route("{name}")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserByName(string name)
        {
            UserResponse? user = await _userService.GetUserByName(name);

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
        public async Task<IActionResult> GetUserById(int id)
        {
            UserResponse? user = await _userService.GetUserById(id);

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
        [Authorize]
        [Route("all")]
        [ProducesResponseType(typeof(UserListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllUsers(int numPag, int elementPag)
        {
            UserListResponse users = await _userService.GetAllUsers(numPag, elementPag);
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
        public async Task<IActionResult> DeleteUser(int id)
        {
            bool result = await _userService.DeleteUser(id);

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
        public async Task<IActionResult> UpdateUser(UserUpdateRequest user, int id)
        {
            
            UserResponse userUpdated = await _userService.UpdateUser(user, id);

            if (string.IsNullOrEmpty(userUpdated.Error))
                return Ok(userUpdated);
            else
                return BadRequest(userUpdated.Error);
        }
    }
}
