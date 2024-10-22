using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public UserController(UserManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO userCreateDTO,string roles)
        {
            var userEntity = mapper.Map<User>(userCreateDTO);
            var result = await userManager.CreateAsync(userEntity,userCreateDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }
            
            var roleCheck = await userManager.IsInRoleAsync(userEntity, roles);
            if (!roleCheck)
            {
                var roleResult = await userManager.AddToRoleAsync(userEntity, roles);
                if (!roleResult.Succeeded)
                {
                    return BadRequest();
                }
            }
            return Ok();

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
