using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Interface
{
    public interface IUserRepository
    {
        Task CreateUser(User user, string password);
        Task<List<User>> GetAllUsers();
        Task<User> GetByID(int ID);
        Task DeleteByID(int ID);
        Task<User> UpdateUser(string userName);
        Task<User> Login(LoginDto login);
        Task LogOut();
    }
}
