using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext context;

        public RoleController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateDTO roleCreate)
        {
            var roleEntity = new Role()
            {
                Name = roleCreate.Name
            };
            await context.Roles.AddAsync(roleEntity);
            await context.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Role> roleEntityList = await context.Roles.ToListAsync();
            List<RoleGetDTO> result = new List<RoleGetDTO>();
            foreach (var role in roleEntityList)
            {
                var roleGetDto = new RoleGetDTO
                {
                    Name = role.Name,
                    Id = role.Id
                };
                result.Add(roleGetDto);
            }
            return Ok(result);
        }
    }
}
