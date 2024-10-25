using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        public AppDbContext Context { get; set; }
        public CategoryRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task CategoryCreate(Category category)
        {
           await Context.Categories.AddAsync(category);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var CategoryEntity = await Context.Categories.ToListAsync();
            if (CategoryEntity == null)
            {
                throw new Exception("Categoires not found!");
            }
            return CategoryEntity;
        }

        public async Task<Category> GetByID(int ID)
        {
            var CategoryEntity = await Context.Categories.FindAsync(ID);
            if (CategoryEntity == null)
            {
                throw new Exception("Category not found!");
            }
            return CategoryEntity;
        }

        public async Task DeleteByID(int ID)
        {
            var CategoryEntity = await Context.Categories.FindAsync(ID);
            Context.Categories.Remove(CategoryEntity);
        }

        public async Task<Category> UpdateCategory(string Name)
        {
            var existCategoryEntity = await Context.Categories.FindAsync(Name);
            return existCategoryEntity;
        }
    }
}
