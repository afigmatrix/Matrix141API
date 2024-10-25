using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; set; }
        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost("NewUser")]
        public async Task<IActionResult> CreateUser(UserCreateDTO userCreateDTO)
        {
           await UserService.UserCreate(userCreateDTO);
           return NoContent();
        }

        [HttpPost("AddUserToRole")]
        public async Task<IActionResult> AddToRoleAsync(int UserId, string roleName)
        {
            await UserService.AddToRole(UserId, roleName);
            return NoContent();
        }

        [HttpGet("AllUsers")]
        public async Task<IActionResult> SelectAllUsers()
        {
            var Result = await UserService.GetAllUsers();
            return  Ok(Result);
        }

        [HttpGet("SpecificUser")]
        public async Task<IActionResult> GetOneUser(int ID)
        {
            var SpecificUser=await UserService.GetUserByID(ID);
            return Ok(SpecificUser);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int ID)
        {
            await UserService.DeleteUserByID(ID);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            await UserService.UpdateUser(userUpdateDTO);
            return NoContent();
        }
    }
}
