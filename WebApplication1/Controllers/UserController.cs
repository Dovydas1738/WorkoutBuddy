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

        [HttpPost("Create a user")]
        public async Task<IActionResult> CreateUser(User user)
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
    }
}
