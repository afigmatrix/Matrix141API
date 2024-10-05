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
        private readonly AppDbContext contex;

        public FacultyController(AppDbContext contex)
        {
            this.contex = contex;
        }
        [HttpPost]
        public async Task Create(Faculty faculty)
        {
            await contex.Faculty.AddAsync(faculty);
            await contex.SaveChangesAsync();
        }
    }
}
