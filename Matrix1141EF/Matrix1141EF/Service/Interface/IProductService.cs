using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Interface
{
    public interface IProductService
    {
        Task CreateProduct(CategoryCreateDTO categoryCreateDTO);
        Task<List<CategoryCreateDTO>> GetAllCategories();
        Task<CategoryGetDTO> GetCategoryByID(int id);
        Task DeleteCategoryByID(int id);
        Task UpdateCategory(ProductCreateDTO productCreateDTO);
    }
}
