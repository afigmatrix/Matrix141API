using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDTO logInDTO)
        {
            logInDTO.Password = HashPassword(logInDTO.Password);
            var email = await _context.Users.FirstOrDefaultAsync(m => m.Email == logInDTO.Email);
            var password = await _context.Users.FirstOrDefaultAsync(m => m.HashPassword == logInDTO.Password);
            if(email == null)
            {
                return Unauthorized();
            }
            if (password == null)
            {
                return Unauthorized();
            }
            else
            {
                var token = GenerateToken();
                var user = await _context.Users.FirstOrDefaultAsync(m => m.Email == logInDTO.Email && m.HashPassword == logInDTO.Password);
                user.Token = token;
                await _context.SaveChangesAsync();
                return Ok(token);
            }
        }
        [HttpPost("logout")]
        public async Task<IActionResult> LogOut (LogOutDTO logOutDTO)
        {
            logOutDTO.Password=HashPassword(logOutDTO.Password);
            var user=await _context.Users.FirstOrDefaultAsync(m=>m.Email == logOutDTO.Email&& m.HashPassword==logOutDTO.Password&& m.Token==logOutDTO.Token);
            if(user == null)
            {
                return Unauthorized();
            }
            else
            {
                user.Token=null;
                await _context.SaveChangesAsync();
                return Ok(user);
            }

        }
        private string GenerateToken()
        {
            return Guid.NewGuid().ToString(); 
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
