using Matrix1141EF.Data.Entity;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Interface
{
    public interface IRoleRepository
    {
        Task CreateRole(Role role);
        Task<Role> GetRole(string roleName);
    }
}
