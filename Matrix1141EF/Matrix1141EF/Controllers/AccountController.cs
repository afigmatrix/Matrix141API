using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IUserService UserService { get; set; }
        public AccountController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserCreateDTO userCreateDTO)
        {
            await UserService.UserCreate(userCreateDTO);
            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var UserResult = await UserService.Login(loginDto);
            return NoContent();
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> LogOut()
        {
            await UserService.LogOut();
            return NoContent();
        }
    }
}
