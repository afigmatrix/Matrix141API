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
    public class RoleController1 : ControllerBase
    {
        private readonly IRoleServiceWithNewTask roleService;
        public RoleController1(IRoleServiceWithNewTask roleServiceWithNewTask)
        {
            this.roleService = roleServiceWithNewTask;
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateDTO roleCreateDTO)
        {
            await roleService.CreateRole(roleCreateDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            await roleService.GetAllRoles();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string id)
        {
            await roleService.DeleteRole(id);
            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> UpdateRole(string id,RoleUpdateDTO roleUpdateDTO)
        {
            await roleService.UpdateRole(id,roleUpdateDTO);
            return NoContent();
        }
    }
}
