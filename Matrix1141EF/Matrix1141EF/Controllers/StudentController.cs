using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentCreateDTO modelDto)
        {
            Student studentEntity = new Student();
            studentEntity.Name = modelDto.Name;
            studentEntity.Age = modelDto.Age;
            studentEntity.BirthDate = modelDto.BirthDate;
            studentEntity.FacultyId = modelDto.FacultyId;
            await _context.Students.AddAsync(studentEntity);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpGet]
        public async Task<List<Student>> ReadAllStudent()
        {
            var result =await _context.Students.Include(m=>m.Faculty).ToListAsync();
            var student = await _context.Students.Where(m => m.Id == 5).FirstOrDefaultAsync();
            var studentWithFaculty = await _context.Students.Include(m=>m.Faculty).Where(m => m.Id == 5).FirstOrDefaultAsync();
            return  result;
        }
    }
}
