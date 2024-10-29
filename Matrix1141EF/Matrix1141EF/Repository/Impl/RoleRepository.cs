using Matrix1141EF.Data.Entity;
using Matrix1141EF.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Impl
{
    public class RoleRepository : IRoleRepository
    {
        public RoleManager<Role> RoleManager { get; set; }
        public RoleRepository(RoleManager<Role> roleManager)
        {
            RoleManager = roleManager;
        }
        public async Task CreateRole(Role role)
        {
            await RoleManager.CreateAsync(role);
        }

        public async Task<Role> GetRole(string roleName)
        {
            var RoleEntity = await RoleManager.FindByNameAsync(roleName);
            return RoleEntity;
        }
    }
}
