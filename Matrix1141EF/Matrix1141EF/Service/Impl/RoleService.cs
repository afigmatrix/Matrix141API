using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Repository.Interface;
using Matrix1141EF.Service.Interface;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Impl
{
    public class RoleService : IRoleService
    {
        public IMapper Mapper { get; set; }
        public IRoleRepository RoleRepository { get; set; }
        public RoleService(IMapper mapper,IRoleRepository roleRepository)
        {
            Mapper = mapper;
            RoleRepository = roleRepository;
        }


        public async Task CreateRole(RoleCreateDTO roleCreateDTO)
        {
            var RoleEntity = Mapper.Map<Role>(roleCreateDTO);
            await RoleRepository.CreateRole(RoleEntity);
        }

        public async Task<RoleGetDTO> GetRole(string roleName)
        {
            var RoleEntity=await RoleRepository.GetRole(roleName);
            var MappedRoleDTO=Mapper.Map<RoleGetDTO>(RoleEntity);
            return MappedRoleDTO;
        }
    }
}
