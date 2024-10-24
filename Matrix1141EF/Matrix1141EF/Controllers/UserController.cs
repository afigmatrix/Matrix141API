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
        public async Task<IActionResult> Create(UserCreateDTO userCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userEntity = mapper.Map<User>(userCreateDTO);
            var userResult = await userManager.CreateAsync(userEntity,userCreateDTO.Password);
            if (userResult.Succeeded)
            {
                return Ok();
            }
            return BadRequest("Xeta bas verdi");
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
