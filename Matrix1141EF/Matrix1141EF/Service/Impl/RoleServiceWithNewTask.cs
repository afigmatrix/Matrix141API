using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Impl
{
    public class RoleServiceWithNewTask : IRoleServiceWithNewTask
    {
        private readonly IMapper mapper;
        private readonly RoleManager<Role> roleManager;
        public RoleServiceWithNewTask(IMapper mapper, RoleManager<Role> roleManager)
        {
            this.mapper = mapper;
            this.roleManager = roleManager;
        }


        public async Task CreateRole(RoleCreateDTO roleCreateDTO)
        {
            var roleEntity = mapper.Map<Role>(roleCreateDTO);
            var resultRole = await roleManager.CreateAsync(roleEntity);
        }


        public async Task<List<RoleGetDTO>> GetAllRoles()
        {
            var roleEntites = await roleManager.Roles.ToListAsync();
            var resultRoles = mapper.Map<List<RoleGetDTO>>(roleEntites);
            return resultRoles;
        }


        public async Task DeleteRole(string id)
        {
            try
            {
                var existRole = await roleManager.FindByIdAsync(id);
                if (existRole == null)
                {
                    throw new Exception("Role not found!");
                }

                var result = await roleManager.DeleteAsync(existRole);
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to delete role: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the role: " + ex.Message);
            }
        }


        public async Task UpdateRole(string id,RoleUpdateDTO roleUpdateDTO)
        {
            try
            {
                var existRole = await roleManager.FindByIdAsync(id);
                mapper.Map(roleUpdateDTO, existRole);
                var resultRole = await roleManager.UpdateAsync(existRole);
                if (!resultRole.Succeeded)
                {
                    throw new Exception("Failed to delete role: " + string.Join(", ", resultRole.Errors.Select(e => e.Description)));
                }
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred while deleting the role: " + ex.Message);
            }
        }
    }
}
