using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult> Create(FacultyCreateDTO createDTO)
        {
            
            var userEntity = new Faculty();
            userEntity.Name = createDTO.Name;
            
            await contex.Faculty.AddAsync(userEntity);
            await contex.SaveChangesAsync();
            return Ok();
           
        }
    }
}
