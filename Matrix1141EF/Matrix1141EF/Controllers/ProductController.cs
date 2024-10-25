using Matrix1141EF.Model.DTO;
using Matrix1141EF.Repository.Impl;
using Matrix1141EF.Service.Impl;
using Matrix1141EF.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductService ProductService { get; set; }
        public ProductController(IProductService productService)
        {
            ProductService = productService; 
        }

        [HttpPost("NewProduct")]
        public async Task<IActionResult> CreateNewProduct(ProductCreateDTO productCreateDTO)
        {
            await ProductService.CreateProduct(productCreateDTO);
            return NoContent();
        }

        [HttpGet("AllProducts")]
        public async Task<IActionResult> SelectAllProducts()
        {
            var Result = await ProductService.GetAllProducts();
            return Ok(Result);
        }

        [HttpGet("SpecificProduct")]
        public async Task<IActionResult> GetOneUser(int ID)
        {
            var SpecificProduct = await ProductService.GetProductByID(ID);
            return Ok(SpecificProduct);
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
