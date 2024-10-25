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
    public class AccountController : ControllerBase
    {
        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }

        public AccountController(SignInManager<User> signInManager,UserManager<User> userManager)
        {
            this.UserManager=userManager;
            this.SignInManager=signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var ExistUser=await UserManager.FindByEmailAsync(loginDTO.Email);
            if (ExistUser==null)
            {
                return BadRequest();
            }
            var Result = await SignInManager.CheckPasswordSignInAsync(ExistUser, loginDTO.Password,false);
            if(Result.Succeeded)
            {
                await SignInManager.SignInAsync(ExistUser,isPersistent:true);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

       

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await SignInManager.SignOutAsync();
            return Ok();
        }

    }
}
