using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext Context;

        public ProductRepository(AppDbContext context)
        {
            this.Context = context;
        }

        public async Task DeleteByID(int ID)
        {
            var ProductEntity = await Context.Products.FindAsync(ID);
            Context.Products.Remove(ProductEntity);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var ProductEntity = await Context.Products.ToListAsync();
            if (ProductEntity == null)
            {
                throw new Exception(" not found!");
            }
            return ProductEntity;
        }

        public async Task<Product> GetByID(int ID)
        {
            var ProductEntity = await Context.Products.FindAsync(ID);
            if (ProductEntity == null)
            {
                throw new Exception("product not found!");
            }
            return ProductEntity;
        }

        public async Task ProductCreate(Product product)
        {
            await Context.Products.AddAsync(product);
        }

        public Task<Product> UpdateProduct(string Name)
        {
            throw new NotImplementedException();
        }

        //Task<User> IProductRepository.GetByID(int ID)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
