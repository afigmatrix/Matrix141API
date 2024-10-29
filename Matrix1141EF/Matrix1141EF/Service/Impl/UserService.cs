using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;
using Matrix1141EF.Repository.Impl;
using Matrix1141EF.Repository.Interface;
using Matrix1141EF.Service.Interface;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Matrix1141EF.Service.Impl
{
    public class UserService : IUserService
    {
        public IMapper Mapper { get; set; }
        public IUserRepository UserRepository { get; set; }
        public UserService(IMapper mapper,IUserRepository userRepository)
        {
            Mapper = mapper;
            UserRepository = userRepository;
        }
        public async Task UserCreate(UserCreateDTO userCreateDTO)
        {
            var UserEntity = Mapper.Map<User>(userCreateDTO);
            await UserRepository.CreateUser(UserEntity, userCreateDTO.Password);
        }

        public async Task<List<UserGetDTO>> GetAllUsers()
        {
            var Result = await UserRepository.GetAllUsers();
            var ResultGetDTO = Mapper.Map<List<UserGetDTO>>(Result);
            return ResultGetDTO;
        }

        public async Task<UserGetDTO> GetUserByID(int id)
        {
            var Result = await UserRepository.GetByID(id);
            var MappedUser = Mapper.Map<UserGetDTO>(Result);
            return MappedUser;
        }

        public async Task DeleteUserByID(int id)
        {
            await UserRepository.DeleteByID(id);
        }

        public async Task<User> UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            var Entity=Mapper.Map<User>(userUpdateDTO);

            var userEntity = await UserRepository.UpdateUser(userUpdateDTO.Name);

            if (userEntity == null)
            {
                return null;
            }

            var bytes = Encoding.UTF8.GetBytes(userUpdateDTO.Password);
            var hashBytes = SHA256.HashData(bytes);
            userEntity.PasswordHash = Convert.ToBase64String(hashBytes);
            userEntity.FinCode = userUpdateDTO.Fincode;

            return userEntity;
        }

        public async Task<User> Login(LoginDto loginDto)
        {
            var UserResult = await UserRepository.Login(loginDto);
            return UserResult;
        }

        public async Task LogOut()
        {
            await UserRepository.LogOut();
        }
    }
}
