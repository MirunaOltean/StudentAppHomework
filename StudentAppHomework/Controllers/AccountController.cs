using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentAppHomework.DTOs;
using StudentAppHomework.Models;
using StudentAppHomework.Services;
using System.Security.Claims;

namespace StudentAppHomework.Controllers
{
    [ApiController]
    [Route("account")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDto payload)
        {
            bool isUnique = await _userService.CheckUsername(payload.Username);

            if (!isUnique)
            {
                return BadRequest("Username is already used!");
            }

            bool result = await _userService.Register(payload);

            if (!result)
            {
                return BadRequest("Register failed!");
            }

            return Ok();
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto payload)
        {
            var jwtToken = await _userService.Validate(payload);

            if (jwtToken == "" || jwtToken == null)
            {
                return BadRequest("Login credentials are wrong.");
            }
            else
            {
                return Ok(new { token = jwtToken });
            }
        }

        [HttpGet("test-auth")]
        public IActionResult TestLogin()
        {
            ClaimsPrincipal user = User;
            var result = "";

            foreach (var claim in user.Claims)
            {
                result += claim.Type + " : " + claim.Value + "\n";
            }

            var hasRole_user = user.IsInRole("User");
            var hasRole_teacher = user.IsInRole("Teacher");

            return Ok(result);
        }

        [HttpGet("students-only")]
        [Authorize(Roles = "Student")]
        public ActionResult<string> HelloStudents()
        {
            return Ok("Hello students!");
        }

        [HttpGet("teacher-only")]
        [Authorize(Roles = "Teacher")]
        public ActionResult<string> HelloTeachers()
        {
            return Ok("Hello teachers!");
        }

    }
}
