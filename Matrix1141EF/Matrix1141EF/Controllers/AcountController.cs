using Matrix1141EF.Data;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AcountController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            if (string.IsNullOrEmpty(userLoginDTO.Email) || string.IsNullOrEmpty(userLoginDTO.Password))
            {
                return BadRequest("Email or Password is not valid!");
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.Email == userLoginDTO.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            var hashedPassword = HashPassword(userLoginDTO.Password);

            if (hashedPassword != user.HashPassword)
            {
                return Unauthorized();
            }
            user.Token = Guid.NewGuid().ToString();
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Ok(user.Token);
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
        [HttpPost("LogOut")]
        public async Task<IActionResult> Logout(LogoutDTO logoutDTO)
        {
            if (string.IsNullOrEmpty(logoutDTO.Email) || string.IsNullOrEmpty(logoutDTO.Password) || string.IsNullOrEmpty(logoutDTO.Token))
            {
                return BadRequest("Email,Password or Token is empty");
            }
            var user = await _context.Users.SingleOrDefaultAsync(m => m.Email == logoutDTO.Email);
            if (user == null)
            {
                return Unauthorized("User is not found");
            }
            var hashedPassword = HashPassword(logoutDTO.Password);
            if (user.HashPassword != hashedPassword || user.Token != logoutDTO.Token)
            {
                return Unauthorized("Password or token is not valid");
            }

            user.Token = null;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return Ok("User update");
        }

    }
}
