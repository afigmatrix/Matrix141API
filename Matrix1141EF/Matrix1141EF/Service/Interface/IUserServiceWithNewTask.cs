using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Interface
{
    public interface IUserServiceWithNewTask
    {
        Task CreateUser(UserCreateDTO userCreateDTO);
        Task<List<UserGetDTO>> GetAllUsers();
        Task<UserGetDTO> GetUserById(int id);
        Task DeleteUser(int id);
        Task UpdateUser(int id, UserUpdateDTO userUpdateDTO);
        Task AddUserToRole(string userID,string roleName);
    }
}
