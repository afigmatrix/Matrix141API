using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Interface
{
    public interface IUserProductService
    {
        Task CreateRelationalUserAndProduct(int userID,int  productID,int count);
        Task CreateUserAndProductAtSameTime(UserCreateDTO userCreateDTO, ProductCreateDTO productCreateDTO, int count);
    }
}
