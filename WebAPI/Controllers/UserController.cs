using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService= userService;
        }
        [SwaggerOperation(Summary ="Zwraca wszystkich użytkowników")]
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [SwaggerOperation(Summary = "Zwraca użytkownikza z podanym id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [SwaggerOperation(Summary ="Dodaje nowego użytkownika")]
        [HttpPost]
        public IActionResult Register(RegisterDto newUser)
        {
            var user = _userService.RegisterUser(newUser);
            return Created($"api/User/{user.Id}", user);
        }
    }
}
