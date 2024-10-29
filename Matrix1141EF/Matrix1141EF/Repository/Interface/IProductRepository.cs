using Matrix1141EF.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Interface
{
    public interface IProductRepository
    {
        Task CreateProduct(Product product);
        Task CreateProductWithCategory(int categoryID,Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetById(string id);
        Task DeleteProduct(string id);
        Task UpdateProduct(Product product);
        Task Submit();
    }
}
