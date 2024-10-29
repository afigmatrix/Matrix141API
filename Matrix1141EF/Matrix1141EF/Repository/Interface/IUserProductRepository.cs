using Matrix1141EF.Data.Entity;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Interface
{
    public interface IUserProductRepository
    {
        Task CreateRelationalUserAndProduct(UserProduct userProduct);
        Task CreateUserAndProductAtSameTime(UserProduct userProduct);
        Task Submit();
    }
}
