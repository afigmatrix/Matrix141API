using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task<List<Category>> GetAllCategories();
        Task<Category> GetById(string id);
        Task DeleteCategory(string id);
        Task UpdateCategory(Category category);
        Task Submit();
    }
}
