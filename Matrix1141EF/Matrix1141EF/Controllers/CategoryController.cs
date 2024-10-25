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
        public ICategoryService CategoryService { get; set; }
        public CategoryController(ICategoryService categoryService)
        {
            CategoryService = categoryService;
        }

        [HttpPost("NewCategory")]
        public async Task<IActionResult> CreateNew(CategoryCreateDTO categoryCreateDTO)
        {
            await CategoryService.CreateProduct(categoryCreateDTO);
            return NoContent();
        }

        [HttpGet("AllCategories")]
        public async Task<IActionResult> SelectAllCategories()
        {
            var Result = await CategoryService.GetAllProducts();
            return Ok(Result);
        }

        [HttpGet("SpecificProduct")]
        public async Task<IActionResult> GetOneCategory(int ID)
        {
            var SpecificCategory = await CategoryService.GetProductByID(ID);
            return Ok(SpecificCategory);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int ID)
        {
            await ProductService.DeleteProductByID(ID);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductCreateDTO productCreateDTO)
        {
            await ProductService.UpdateProduct(productCreateDTO);
            return NoContent();
        }
    }
}
