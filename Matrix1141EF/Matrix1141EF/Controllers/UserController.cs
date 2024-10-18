using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UserController(UserManager<User> userManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO createDTO)
        {
            var userEntity = new User()
            {
                Name = createDTO.Name,
                Age = 30,
                Email = createDTO.Email,
                UserName = createDTO.Email
            };
            var saveResult = await userManager.CreateAsync(userEntity, createDTO.Password);
            if (saveResult.Succeeded)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var allUsers = await userManager.Users.ToListAsync();
            var result = mapper.Map<List<UserGetDTO>>(allUsers);
            return Ok(result);
        }

    }
}
