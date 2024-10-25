using AutoMapper;
using Matrix1141EF.Data;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AppDbContext context { get; set; }
        public  IMapper  mapper { get; set; }
        public AdminController(AppDbContext context,IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var AllStudents=await context.Students.ToListAsync();
            var Result=mapper.Map<StudentGetDTO>(AllStudents);
            return Ok(Result);
        }



    }
}
