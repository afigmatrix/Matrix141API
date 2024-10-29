using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Interface
{
    public interface IUserService
    {
        Task UserCreate(UserCreateDTO userCreateDTO);
        Task<List<UserGetDTO>> GetAllUsers();
        Task<UserGetDTO> GetUserByID(int id);
        Task DeleteUserByID(int id);
        Task<User> UpdateUser(UserUpdateDTO userUpdateDTO);
        Task<User> Login(LoginDto loginDto);
        Task LogOut();
    }
}
