using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context;

        public UserController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDTO userCreateDto)
        {
            if (string.IsNullOrEmpty(userCreateDto.Password) || userCreateDto.Password.Length < 6)
            {
                return BadRequest("Password is not valid!");
            }

            var userEntity = new User();
            userEntity.Name = userCreateDto.Name;
            userEntity.Email = userCreateDto.Email;
            userEntity.HashPassword = HashPassword(userCreateDto.Password);
            foreach(var roleId in userCreateDto.RoleIds) //1,2
            {
                var roleEntity = await context.Roles.FindAsync(roleId);
                if (roleEntity != null)
                {
                    userEntity.Roles.Add(roleEntity);
                }
            } 
            await context.Users.AddAsync(userEntity);
            await context.SaveChangesAsync();
            return NoContent();
        }

        

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userList = await context.Users.Include(m => m.Roles).ToListAsync();
            return Ok(userList);
        }

        private string HashPassword(string password)
        {
            using (SHA256 sHA256 = SHA256.Create())
            {
                byte[] hashedData = sHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashedData)
                {
                    sb.Append(b.ToString("x2"));
                    //x2 yeni hexadecimal formatda
                }
                return sb.ToString();
            }
        }
    }
}
