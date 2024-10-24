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
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RoleController(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateDTO roleCreateDTO)
        {
            if (string.IsNullOrEmpty(roleCreateDTO.RoleName))
            {
                return BadRequest("Rol adi bos ola bilmez!");
            }
            var roleExist = await _roleManager.RoleExistsAsync(roleCreateDTO.RoleName);
           
            if (!roleExist)
            {
                var role = _mapper.Map<Role>(roleCreateDTO);
                var roleResult = await _roleManager.CreateAsync(role);

                if (roleResult.Succeeded)
                {
                    return Ok("Rol yaradildi");
                }
                
                
            }
            return BadRequest("Bu rol artiq movcuddur!");

        }
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(UserRoleDTO userRoleDTO)
        {
            var user = await _userManager.FindByNameAsync(userRoleDTO.UserName);
            if (user == null)
            {
                return NotFound();
            }
            var role = await _roleManager.RoleExistsAsync(userRoleDTO.RoleName);
            if (!role)
            {
                return NotFound();
            }
            var result = await _userManager.AddToRoleAsync(user,userRoleDTO.RoleName);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
                
            
        }
    }
}
