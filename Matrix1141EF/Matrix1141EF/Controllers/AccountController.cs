using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;
using Matrix1141EF.Model.DTO;

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

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ExistUser = await context.Users.Where(m => m.Email == loginDTO.Email && m.HashPassword == HashPassword(loginDTO.Password)).FirstOrDefaultAsync();

            if (ExistUser == null)
            {
                return Unauthorized(new { message = "Invalid email or password!" });
            }

            var Token = GenerateManualToken(ExistUser);

            ExistUser.Token = Token;

            context.Users.Update(ExistUser);
            await context.SaveChangesAsync();

            return Ok(new { Token });
        }

        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut(LogOutDTO logOutDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var user = HttpContext.Items["User"] as User;

            var ExistUser = await context.Users.Where(m => m.Email == logOutDTO.Email && m.HashPassword == HashPassword(logOutDTO.Password) && m.Token == logOutDTO.Token).FirstOrDefaultAsync();

            if (ExistUser == null)
            {
                return Unauthorized(new { message = "Invalid data!" });
            }

            ExistUser.Token = null;
            context.Users.Update(ExistUser);
            await context.SaveChangesAsync();
            return Ok(new { message = "Successfully logged out" });
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] HashedData = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in HashedData)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private string GenerateManualToken(User user)
        {
            string Token = Guid.NewGuid().ToString();

            return Token;
        }
    }
}
}
