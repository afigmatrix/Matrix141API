using Matrix1141EF.Data;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.Intrinsics.Arm;
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

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
        {
            if (string.IsNullOrEmpty(loginDTO.Email) || string.IsNullOrEmpty(loginDTO.Password))
            {
                    return BadRequest("Email or Password is not correct!");
            }

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == loginDTO.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = Guid .NewGuid().ToString();
            user.Token = token;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogOutDTO logoutDto)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Email == logoutDto.Email &&
                                           HashPassword(logoutDto.Password) == u.HashPassword &&
                                           u.Token == logoutDto.Token);

            if (user == null)
            {
                return Unauthorized();
            }

            user.Token = null;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok();
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

    }
}
