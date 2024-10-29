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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly AppDbContext context;

        public CategoryController(ICategoryService categoryService,AppDbContext context)
        {
            this.categoryService = categoryService;
            this.context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateDTO categoryCreateDTO)
        {
            await categoryService.CreateCategory(categoryCreateDTO);
            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var resultCategories=await categoryService.GetAllCategories();
            return Ok(resultCategories);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetByID(string id)
        {
            var resultCategory=await categoryService.GetByID(id);
            return Ok(resultCategory);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategories(string id)
        {
            await categoryService.DeleteCategory(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(string id,CategoryUpdateDTO categoryUpdateDTO)
        {
            await categoryService.UpdateCategory(id,categoryUpdateDTO);
            return NoContent();
        }
    }
}
