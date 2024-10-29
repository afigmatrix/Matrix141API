using Matrix1141EF.Model.DTO;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Interface
{
    public interface IRoleService
    {
        Task CreateRole(RoleCreateDTO roleCreateDTO);
        Task<RoleGetDTO> GetRole(string roleName);
    }
}
