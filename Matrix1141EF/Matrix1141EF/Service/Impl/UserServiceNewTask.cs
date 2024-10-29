using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Impl
{
    public class UserServiceNewTask : IUserServiceWithNewTask
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public UserServiceNewTask(IMapper mapper,UserManager<User> userManager,RoleManager<Role> roleManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task CreateUser(UserCreateDTO userCreateDTO)
        {
            var userEntity=mapper.Map<User>(userCreateDTO);
            await userManager.CreateAsync(userEntity);
        }

        public async Task<List<UserGetDTO>> GetAllUsers()
        {
            var allUSers=await userManager.Users.ToListAsync();
            var resultUsers = mapper.Map<List<UserGetDTO>>(allUSers);
            return resultUsers;
        }

        public async Task<UserGetDTO> GetUserById(int id)
        {
            var existUsers = await userManager.FindByIdAsync(Convert.ToString(id));
            if(existUsers == null)
            {
                throw new Exception("User not found!");
            }
            var userEntity=mapper.Map<UserGetDTO>(existUsers);
            return userEntity;
        }

        public async Task DeleteUser(int id)
        {
            var existUser = await userManager.FindByIdAsync(Convert.ToString((id)));
            if (existUser == null)
            {
                throw new Exception("User not found!");
            }
            await userManager.DeleteAsync(existUser);
        }

        public async Task UpdateUser(int id, UserUpdateDTO userUpdateDTO)
        {
            var existUser = await userManager.FindByIdAsync(Convert.ToString((id)));
            if (existUser == null)
            {
                throw new Exception("User not found!");
            }
            mapper.Map(userUpdateDTO,existUser);
            var resultUser = await userManager.UpdateAsync(existUser);
            if(!resultUser.Succeeded)
            {
                throw new Exception("Failed to update user!");
            }
        }

        public async Task AddUserToRole(string userID, string roleName)
        {
            var existUser=await userManager.FindByIdAsync(userID);
            var existRole=await roleManager.FindByNameAsync(roleName);
            try
            {
                var result = await userManager.AddToRoleAsync(existUser, roleName);
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to add user to role: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding user to role: " + ex.Message);
            }
        }
    }
}
