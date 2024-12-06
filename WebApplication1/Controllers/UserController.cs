using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WorkoutBuddy.Core.Contracts;
using WorkoutBuddy.Core.Models;
using WorkoutBuddy.Core.Services;
using WorkoutBuddy.Api.Requests;
using Azure.Core;

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
        public async Task<IActionResult> RegisterUser([FromBody]UserRegisterRequest registerRequest)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(registerRequest.Username);

                if (user == null)
                {
                    await _userService.CreateUserAsync(new User
                    {
                        Username = registerRequest.Username,
                        Password = registerRequest.Password
                    });
                    return Ok(new {Message = "User registered successfully."});
                }
                else
                {
                    return Conflict(new { Message = "User already exists." });
                }
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        [HttpPost("users/login")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginRequest loginRequest)
        {
            try
            {
                var user = await _userService.GetUserByUsernameAsync(loginRequest.Username);

                if(user == null)
                {
                    return Conflict(new { Message = "User not found." });
                }
                else
                {
                    if(user.Password == loginRequest.Password)
                    {
                        var tokenService = HttpContext.RequestServices.GetRequiredService<JwtTokenService>();
                        var token = tokenService.GenerateToken(user.UserId, loginRequest.Username);


                        return Ok(new
                        {
                            Message = "Login successful.",
                            Username = user.Username,
                            Token = token
                        });
                    }
                    else
                    {
                        return Unauthorized(new {Message = "Password is incorrect."});
                    }
                }

            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }
    }
}
