﻿using gwl_voices.Application.Mappers;
using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.User;
using gwl_voices.DataAccess.Contracts;
using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;

namespace gwl_voices.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _uOw;

        public UserService(IUserRepository userRepository, IUnitOfWork uOw)
        { 
            _userRepository = userRepository;
            _uOw = uOw;
        }
        public UserResponse? GetUserByName(string name)
        {
            UserDto? user = _userRepository.GetUserByName(name);

            UserResponse result = new UserResponse();

            if (user != null)
            {
                result = UserMapper.MapToUserResponseFromUserDto(user);
            }
            else return null;
            return result;

           
        }

        public UserResponse? GetUserById(int id)
        {
            UserDto? user = _userRepository.GetUserById(id);

            UserResponse result = new UserResponse();
            if (user != null)
            {
                result = UserMapper.MapToUserResponseFromUserDto(user);
            }
            else return null;
            return result;
        }


        public UserResponse AddUser(UserRequest user)
        {
            UserDto newUser = UserMapper.MapToUserDtoFromUserRequest(user);

            UserDto userInserted = _userRepository.AddUser(newUser);

            _uOw.SaveChanges();

            UserResponse result = UserMapper.MapToUserResponseFromUserDto(userInserted);
            return result;
        }


        public bool DeleteUser(int id)
        {
            UserDto? user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return false;
            }
            else
            {
                _userRepository.DeleteUser(user);

                _uOw.SaveChanges();
                return true;

            }
        }

        public UserResponse UpdateUser(UserUpdateRequest user, int id)
        {
            UserDto newUser = new UserDto
            {
                Id = id,
                Username = user.Username,
                Password = user.Password,
                Rol = user.Rol,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Img = user.Img,
                Phone = user.Phone,
                Adress = user.Adress,
                UrlGwl = user.UrlGwl,
            };

            UserDto userUpdated = _userRepository.UpdateUser(newUser);

            _uOw.SaveChanges();

            UserResponse result = UserMapper.MapToUserResponseFromUserDto(userUpdated);

            return result;
        }

    }
}
