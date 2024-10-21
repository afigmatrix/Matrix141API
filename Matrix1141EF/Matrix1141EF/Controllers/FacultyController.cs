using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly AppDbContext context;

        public FacultyController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Faculty faculty)
        {
            if (faculty == null)
            {
                return BadRequest("Faculty cannot be null");
            }

            await context.Faculty.AddAsync(faculty);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
