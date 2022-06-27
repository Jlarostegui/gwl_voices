using gwl_voices.BusinessModels.Models.User;
using gwl_voices.DataAccess.Contracts.Dto;

namespace gwl_voices.Application.Mappers
{
    public static class UserMapper
    {
        public static UserResponse MapToUserResponseFromUserDto(loginResponse userDto)
        {
            UserResponse result = new UserResponse
            {
                Username = userDto.Username,
                Name = userDto.Name,
                Id = userDto.Id,
                Surname = userDto.Surname,
                Rol = userDto.Rol,
                Phone = userDto.Phone,
                Email = userDto.Email,

            };

            return result;
        }

        public static loginResponse MapToUserDtoFromUserRequest(UserRequest userRequest)
        {
            loginResponse user = new loginResponse
            {
                Id = userRequest.Id,
                Username = userRequest.Username,
                Password = userRequest.Password,
                Rol = userRequest.Rol,
                Name = userRequest.Name,
                Surname = userRequest.Surname,
                Email = userRequest.Email,
                Img = userRequest.Img,
                Phone = userRequest.Phone,
                Adress = userRequest.Adress,
                UrlGwl = userRequest.UrlGwl,
            };

            return user;
        }

    }
}
