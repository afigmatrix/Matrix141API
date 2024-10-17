using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext context;

        public AccountController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (string.IsNullOrEmpty(loginDTO.Email) || string.IsNullOrEmpty(loginDTO.Password))
            {
                return NotFound();
            }
            var user = await context.Users.FirstOrDefaultAsync(u=>u.Email == loginDTO.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            var hashedpassword = HashPassword(loginDTO.Password);
            if (user.HashPassword != hashedpassword)
            {
                return Unauthorized("Wrong password");
            }
            var token = Guid.NewGuid().ToString();
            user.Token = token;
            await context.SaveChangesAsync();
            return Ok(token);
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
                }
                return sb.ToString();
            }
        }
        public async Task<IActionResult> LogOut (LogOutDTO logOutDTO)
        {
            if (string.IsNullOrEmpty(logOutDTO.Email) || string.IsNullOrEmpty(logOutDTO.Password))
            {
                return NotFound();
            }
            var user =  await context.Users.FirstOrDefaultAsync(u => u.Email == logOutDTO.Email);
            if (user == null)
            {
                return Unauthorized();
            }
            var hashedPassword = HashPassword(logOutDTO.Password);

            if (user.HashPassword != hashedPassword || user.Token != logOutDTO.Token)
            {
                return Unauthorized();
            }
            user.Token = null; 
            await context.SaveChangesAsync(); 

            return Ok();
        }
    }
}
