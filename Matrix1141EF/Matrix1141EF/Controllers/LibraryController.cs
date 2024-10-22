using Matrix1141EF.Data;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            this.libraryService = libraryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(LibraryCreateDto model)
        {
            await libraryService.Create(model);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetLibraryById(int id)
        {
            LibraryGetByIdDto result = await libraryService.GetLibraryById(id);
            return Ok(result);
        }

        //Global Query Filter
    }
}
