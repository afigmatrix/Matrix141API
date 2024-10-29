using Matrix1141EF.Data;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Repository.Interface;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Impl
{
    public class UserProductRepository : IUserProductRepository
    {
        private readonly AppDbContext context;

        public UserProductRepository(AppDbContext context)
        {
            this.context = context;
        }


        public async Task CreateRelationalUserAndProduct(UserProduct userProduct)
        {
            await context.UserProducts.AddAsync(userProduct);
            await Submit();
        }


        public async Task CreateUserAndProductAtSameTime(UserProduct userProduct)
        {
            await context.UserProducts.AddAsync(userProduct);
            await Submit();
        }


        public async Task Submit()
        {
            await context.SaveChangesAsync();
        }
    }
}
