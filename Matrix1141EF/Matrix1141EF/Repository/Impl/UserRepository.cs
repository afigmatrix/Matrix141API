using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrix1141EF.Repository.Impl
{
    public class UserRepository : IUserRepository
    {
        public SignInManager<User> SignInManager { get; set; }
        public UserManager<User> UserManager { get; set; }
        public UserRepository(SignInManager<User> signInManager,UserManager<User> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }
        public async Task CreateUser(User user, string password)
        {
            var Result = await UserManager.CreateAsync(user, password);

            if (!Result.Succeeded)
            {
                var errors = string.Join(", ", Result.Errors.Select(e => e.Description));

                throw new Exception($"User creation failed: {errors}");
            }
        }


        public async Task<List<User>> GetAllUsers()
        {
            var UserEntity = await UserManager.Users.ToListAsync();
            if (UserEntity == null)
            {
                throw new Exception("Users not found!");
            }
            return UserEntity;
        }


        public async Task<User> GetByID(int ID)
        {
            var UserEntity = await UserManager.FindByIdAsync(Convert.ToString(ID));
            if (UserEntity == null)
            {
                throw new Exception("user not found!");
            }
            return UserEntity;
        }


        public async Task DeleteByID(int ID)
        {
            var UserEntity = await UserManager.FindByIdAsync(Convert.ToString(ID));
            await UserManager.DeleteAsync(UserEntity);
        }

        //public async Task<User> UpdateUser(string username)
        //{
        //    var existUserEntity = await UserManager.FindByNameAsync(username);
            
        //}

        public async Task<User> Login(LoginDto loginDto)
        {
            var UserResult = await UserManager.FindByEmailAsync(loginDto.Email);
            var SignInResult = await SignInManager.CheckPasswordSignInAsync(UserResult, loginDto.Password, false);
            return UserResult;
        }

        public async Task LogOut()
        {
            await SignInManager.SignOutAsync();
        }

        public Task<User> UpdateUser(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
