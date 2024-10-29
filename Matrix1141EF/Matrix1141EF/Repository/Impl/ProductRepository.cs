using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }


        public async Task CreateProduct(Product product)
        {
            await context.Products.AddAsync(product);
            await Submit();
        }


        public async Task<List<Product>> GetAllProducts()
        {
            var productEntity = await context.Products.ToListAsync();
            return productEntity;
        }


        public async Task DeleteProduct(string id)
        {
            var existProduct = await context.Products.FindAsync(id);
            context.Remove(existProduct);
            await Submit();
        }


        public async Task Submit()
        {
            await context.SaveChangesAsync();
        }

        public async Task<Product> GetById(string id)
        {
            var productEntity = await context.Products.FindAsync(id);
            return productEntity;
        }

        public async Task UpdateProduct(Product product)
        {
            context.Products.Update(product);
            await Submit();
        }

        public async Task CreateProductWithCategory(int categoryID, Product product)
        {
            product.CategoryID = categoryID;
            await context.Products.AddAsync(product);
        }
    }
}
