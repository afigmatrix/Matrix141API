using Matrix1141EF.Model;
using Matrix1141EF.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Interface
{
    public interface IProductService
    {
        Task CreateProduct(ProductCreateDTO productCreateDTO);
        Task CreateProductWithCategory(int categoryID, ProductCreateDTO productCreateDTO);
        Task<List<ProductGetDTO>> GetAllProducts();
        Task<ProductGetDTO> GetByID(string id);
        Task DeleteProduct(string id);
        Task UpdateProduct(string id, ProductUpdateDTO productUpdateDTO);
    }
}
