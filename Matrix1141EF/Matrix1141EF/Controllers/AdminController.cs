using Matrix1141EF.Service.Impl;
using Matrix1141EF.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IStudentService StudentService { get; set; }
        public AdminController(IStudentService studentService)
        {
            StudentService = studentService;
        }

        [HttpGet("AllStudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            var Result=await StudentService.GetAllUsers();
            return Ok(Result);
        }
    }
}
