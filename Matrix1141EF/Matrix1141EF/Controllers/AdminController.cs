using Matrix1141EF.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{

    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly List<Student> _students;

        public AdminController()
        {
            _students = new List<Student>
            {
                new Student { Id = 1, Name = "Teymur Akhmadov"},
                new Student { Id = 2, Name = "Galata Saray"}

            };
        }

        [HttpGet("Students")]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(_students);
        }
    }
}
