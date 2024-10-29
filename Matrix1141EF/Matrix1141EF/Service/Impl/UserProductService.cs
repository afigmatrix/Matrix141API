using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Repository.Interface;
using Matrix1141EF.Service.Interface;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Impl
{
    public class UserProductService : IUserProductService
    {
        private readonly IUserProductRepository userProductRepository; 
        private readonly IMapper mapper;
        public UserProductService(IUserProductRepository userProductRepository,IMapper mapper)
        {
            this.userProductRepository = userProductRepository;
            this.mapper = mapper;
        }
        public async Task CreateRelationalUserAndProduct(int userID,int productID,int count)
        {
            UserProduct userProduct=new UserProduct();
            userProduct.ProductID = productID;
            userProduct.UserID = userID;
            userProduct.Count = count;
            await userProductRepository.CreateRelationalUserAndProduct(userProduct);
        }

        public async Task CreateUserAndProductAtSameTime(UserCreateDTO userCreateDTO, ProductCreateDTO productCreateDTO, int count)
        {
            var userEntity=mapper.Map<User>(userCreateDTO);
            var productEntity=mapper.Map<Product>(productCreateDTO);
            UserProduct userProduct=new UserProduct();
            userProduct.User=userEntity;
            userProduct.Product=productEntity;
            userProduct.Count=count;
            await userProductRepository.CreateUserAndProductAtSameTime(userProduct);
        }
    }
}
