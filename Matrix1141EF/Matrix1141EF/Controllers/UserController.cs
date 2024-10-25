using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> UserManager;
        private readonly IMapper Mapper;
        public UserController(UserManager<User> userManager,IMapper mapper)
        {
            userManager = userManager;
            Mapper= mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserCreateDTO userCreateDTO)
        {
            var UserEntity = new User()
            {
                Name = userCreateDTO.Name,
                Email = userCreateDTO.Email,
                FinCode = "7836e4hvsd8"
            };
        var UserResult=await UserManager.CreateAsync(UserEntity,userCreateDTO.Password);

            if(UserResult.Succeeded)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }    
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var AllUsers = await UserManager.Users.ToListAsync();
            var Result=Mapper.Map<UserCreateDTO>(AllUsers);
            return Ok(Result);
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRoleToUser(string userEmail, string roleName)
        {
            var user = await UserManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return BadRequest("İstifadəçi tapılmadı.");
            }

            var result = await UserManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return Ok($"İstifadəçiyə '{roleName}' rolu əlavə olundu.");
            }

            return BadRequest(result.Errors);
        }



    }
}
