using Matrix1141EF.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles ="Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext context;

        public AdminController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await context.Students.Include(m=> m.Faculty).ToListAsync();
            return Ok(result);
        }
    }
}
