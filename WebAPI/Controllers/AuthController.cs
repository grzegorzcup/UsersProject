using Application.Authentication;
using Application.DTO;
using Application.DTO.Responses;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagmentController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly JWTConfig _jWTConfig;
        private readonly PostService _postService;

        public AuthManagmentController(UserManager<User> userManager, IOptionsMonitor<JWTConfig> optionsMonitor, PostService postService)
        {
            _userManager = userManager;
            _jWTConfig = optionsMonitor.CurrentValue;
            _postService = postService;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegistrationDto user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new RegistrationResponse()
                {
                    Errors = new List<string>()
                    {
                        "Invalid pauload"
                    },
                    Succes = false
                });
            }

            var existingUser = await _userManager.FindByNameAsync(user.UserName);

            if (existingUser != null)
            {
                return BadRequest(new RegistrationResponse()
                {
                    Errors = new List<string>()
                    {
                        "Login already in use"
                    },
                    Succes = false
                });
            }

            var newUser = new IdentityUser() { UserName = user.UserName };
            var isCreated = await _userManager.CreateAsync(newUser, user.Password);
        }
    }
}
