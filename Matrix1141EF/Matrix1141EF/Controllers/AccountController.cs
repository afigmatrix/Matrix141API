using Matrix1141EF.Data.Entity;
using Matrix1141EF.Events;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController :IdentityDbContext<User,Role,int>
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public event EventHandler<LoginFailedEvent> OnLoginFailed;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var user = await userManager.FindByEmailAsync(login.Email);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            var signInResult = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (signInResult.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Ok(new { message = "Login successful" });
            }
            else
            {
                var loginFailedEvent = new LoginFailedEvent
                {
                    Username = login.Email,
                    Timestamp = DateTime.UtcNow
                };

                OnLoginFailed?.Invoke(this, loginFailedEvent);

                return Unauthorized(new { message = "Invalid credentials" });
            }
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok(new { message = "Logout successful" });
        }
    }
}
