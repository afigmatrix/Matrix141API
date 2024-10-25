using Matrix1141EF.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task CategoryCreate(Category category);
        Task<List<Category>> GetAllCategories();
        Task<Category> GetByID(int ID);
        Task DeleteByID(int ID);
        Task<Category> UpdateCategory(string Name);
    }
}
