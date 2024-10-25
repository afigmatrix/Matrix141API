using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public RoleManager<Role> RoleManager { get; set; }

        private IMapper mapper { get; set; }

        public RoleController(RoleManager<Role> roleManager, IMapper mapper)
        {
            this.RoleManager = roleManager;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateDTO roleCreateDTO)
        {
            var RoleResult = mapper.Map<Role>(roleCreateDTO);
            var ExistRole = await RoleManager.CreateAsync(RoleResult);
            if (ExistRole.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
