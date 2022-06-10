using gwl_voices.BusinessModels.Models.User;
using gwl_voices.DataAccess.Contracts.Dto;

namespace gwl_voices.Application.Mappers
{
    public static class UserMapper
    {
        public static UserResponse MapToUserResponseFromUserDto(UserDto userDto)
        {
            UserResponse result = new UserResponse
            {
                UserName = userDto.Username,
                Name = userDto.Name,
                id = userDto.Id,
            };

            return result;
        }

        public static UserDto MapToUserDtoFromUserRequest(UserRequest userRequest)
        {
            UserDto user = new UserDto
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
