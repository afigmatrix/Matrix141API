using Matrix1141EF.Data.Entity;
using Matrix1141EF.Data;
using Matrix1141EF.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Matrix1141EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;


        }





        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDTO modelDto)
        {
            Product productEntity = new Product();
            productEntity.Name = modelDto.Name;
            productEntity.Price = modelDto.Price;
            productEntity.CategoryName = modelDto.CategoryName;
            productEntity.Currency = modelDto.Currency;

            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]

        public async Task<List<Product>> ReadProduct()
        {
            var result = _context.Products.ToListAsync();
            return await result;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductCreateDTO modelDto)
        {
            var productEntity = await _context.Products.FindAsync(id);

            if (productEntity == null)
            {
                return NotFound();
            }

            productEntity.Name = modelDto.Name;
            productEntity.Price = modelDto.Price;
            productEntity.CategoryName = modelDto.CategoryName;
            productEntity.Currency = modelDto.Currency;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delateroduct(int id, ProductCreateDTO modelDto)
        {
            var productEntity = await _context.Products.FindAsync(id);

            if (productEntity == null)
            {
                return NotFound();
            }


            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
