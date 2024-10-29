using Matrix1141EF.Model.DTO;
using Matrix1141EF.Service.Impl;
using Matrix1141EF.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController1 : ControllerBase
    {
        private readonly IUserServiceWithNewTask userServiceNewTask;

        public UserController1(IUserServiceWithNewTask userServiceNewTask)
        {
            this.userServiceNewTask = userServiceNewTask;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateDTO userCreateDTO)
        {
            await userServiceNewTask.CreateUser(userCreateDTO);
            return NoContent();
        }

        [HttpPost("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string userID, string roleName)
        {
            await userServiceNewTask.AddUserToRole(userID, roleName);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var resultUsers= await userServiceNewTask.GetAllUsers();
            return Ok(resultUsers);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetFindByID(int ID)
        {
            var resultUser=await userServiceNewTask.GetUserById(ID);
            return Ok(resultUser);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteByID(int ID)
        {
            await userServiceNewTask.DeleteUser(ID);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(int ID, UserUpdateDTO userUpdateDTO)
        {
            await userServiceNewTask.UpdateUser(ID, userUpdateDTO);
            return NoContent();
        }
    }
}
