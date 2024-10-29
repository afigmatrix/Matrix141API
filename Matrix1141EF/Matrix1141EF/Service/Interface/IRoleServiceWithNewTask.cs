using Matrix1141EF.Model.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Interface
{
    public interface IRoleServiceWithNewTask
    {
        Task CreateRole(RoleCreateDTO roleCreateDTO);
        Task<List<RoleGetDTO>> GetAllRoles();
        Task DeleteRole(string id);
        Task UpdateRole(string id,RoleUpdateDTO roleUpdateDTO);
    }
}
