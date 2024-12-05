using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WorkoutBuddy.Core.Contracts;
using WorkoutBuddy.Core.Models;
using WorkoutBuddy.Core.Services;

namespace WorkoutBuddy.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("users/register")]
        public async Task<IActionResult> RegisterUser([FromBody]User user)
        {
            try
            {
                await _userService.CreateUserAsync(user);
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("users/authenticate")]
        public async Task<IActionResult> AuthenticateUser([FromBody] LoginRequest login)
        {
            var token = await _userService.Authenticate(login.Username, login.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
