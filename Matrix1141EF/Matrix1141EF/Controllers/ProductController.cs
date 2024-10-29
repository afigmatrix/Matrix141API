using AutoMapper;
using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
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
        private readonly IProductService productService;
        private readonly IUserProductService userProductService;

        public ProductController(IProductService productService,IUserProductService userProductService)
        {
            this.productService = productService;
            this.userProductService = userProductService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDTO productCreateDTO)
        {
            await productService.CreateProduct(productCreateDTO);
            return NoContent();
        }


        [HttpPost("ProductWithCategory")]
        public async Task<IActionResult> CreateProductWithCategory(int categoryID,ProductCreateDTO productCreateDTO)
        {
            await productService.CreateProductWithCategory(categoryID, productCreateDTO);
            return NoContent();
        }


        [HttpPost("ProductWithUser")]
        public async Task<IActionResult> CreateProductTogetherUser(int productID,int userID,int count)
        {
            await userProductService.CreateRelationalUserAndProduct(productID, userID, count);
            return NoContent();
        }


        [HttpPost("ProductWithUserRelational")]
        public async Task<IActionResult> CreateProductWithUser(ProductCreateDTO productCreateDTO,UserCreateDTO userCreateDTO,int count)
        {
          await userProductService.CreateUserAndProductAtSameTime(userCreateDTO, productCreateDTO, count);
            return NoContent(); 
        }


        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var resultProducts = await productService.GetAllProducts();
            return Ok(resultProducts);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetByID(string id)
        {
            var resultProduct = await productService.GetByID(id);
            return Ok(resultProduct);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProducts(string id)
        {
            await productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(string id, ProductUpdateDTO productUpdateDTO)
        {
            await productService.UpdateProduct(id, productUpdateDTO);
            return NoContent();
        }
    }
}
