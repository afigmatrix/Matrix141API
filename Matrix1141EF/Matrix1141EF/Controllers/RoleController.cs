using Matrix1141EF.Model.DTO;
using Matrix1141EF.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public IRoleService RoleService { get; set; }
        public RoleController(IRoleService roleService)
        {
            RoleService = roleService;
        }

        [HttpPost("NewRole")]
        public async Task<IActionResult> CreateRole(RoleCreateDTO roleCreateDTO)
        {
            await RoleService.CreateRole(roleCreateDTO);
            return NoContent();
        }

        [HttpGet("AllRole")]
        public async Task<IActionResult> GetAllRole(string roleName)
        {
            var RoleResultDTO=await RoleService.GetRole(roleName);
            return Ok(RoleResultDTO);
        }
    }
}
