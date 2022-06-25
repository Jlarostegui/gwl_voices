﻿using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.gwl_Context;

namespace gwl_voices.DataAccess.Mappers
{
    public static class UserMapper
    {
        public static loginResponse MapToUserDtoFromUser(User user)
        {
            loginResponse result = new loginResponse

            {
                Id = user.Id,
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

            return result;
        }

        public static User MapToUserFromUserDto(loginResponse userDto)
        {
            User user = new User
            {

                Username = userDto.Username,
                Password = userDto.Password,
                Rol = userDto.Rol,
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                Img = userDto.Img,
                Phone = userDto.Phone,
                Adress = userDto.Adress,
                UrlGwl = userDto.UrlGwl,
            };

            return user;
        }


    }
}
