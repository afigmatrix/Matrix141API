using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Interface
{
    public interface ICategoryService
    {
        Task CreateProduct(CategoryCreateDTO categoryCreateDTO);
        Task<List<ProductGetDTO>> GetAllProducts();
        Task<ProductGetDTO> GetProductByID(int id);
        Task DeleteProductByID(int id);
        Task<Product> UpdateProduct(UpdateProductDTO updateProductDTO);
        Task UpdateProduct(ProductCreateDTO productCreateDTO);
    }
}
