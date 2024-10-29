using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task CreateCategory(Category category)
        {
            await context.Categories.AddAsync(category);
            await  Submit();
        }


        public async Task<List<Category>> GetAllCategories()
        {
            var categoryEntity=await context.Categories.ToListAsync();
            return categoryEntity;
        }


        public async Task DeleteCategory(string id)
        {
            var ExistUser=await context.Categories.FindAsync(id);
            context.Remove(ExistUser);
            await Submit();
        }


        public async Task Submit()
        {
           await context.SaveChangesAsync();
        }

        public async Task UpdateCategory(string id, Category category)
        {
            var categoryEntity=await context.Categories.FindAsync(id);
            
        }

        public async Task<Category> GetById(string id)
        {
            var categoryEntity= await context.Categories.FindAsync(id);
            return categoryEntity;
        }

        public async Task UpdateCategory(Category category)
        {
            context.Categories.Update(category);
            await Submit();
        }
    }
}
