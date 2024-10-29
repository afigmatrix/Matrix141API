using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Interface
{
    public interface ICategoryService
    {
        Task CreateCategory(CategoryCreateDTO categoryCreateDTO);
        Task<List<CategoryGetDTO>> GetAllCategories();
        Task<CategoryGetDTO> GetByID(string id);
        Task DeleteCategory(string id);
        Task UpdateCategory(string id, CategoryUpdateDTO categoryUpdateDTO);
    }
}
