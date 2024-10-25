using Matrix1141EF.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Interface
{
    public interface IProductRepository
    {
        Task ProductCreate(Product product);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetByID(int ID);
        Task DeleteByID(int ID);
        Task<Product> UpdateProduct(string Name);
    }
}
