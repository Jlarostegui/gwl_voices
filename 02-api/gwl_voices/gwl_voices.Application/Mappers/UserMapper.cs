using gwl_voices.BusinessModels.Models.User;
using gwl_voices.BusinessModels.Models.WorkingGroup;
using gwl_voices.DataAccess.Contracts.Dto;

namespace gwl_voices.Application.Mappers
{
    public static class UserMapper
    {
        public static UserResponse MapToUserResponseFromUserDto(UserDto userDto)
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
                WorkingGroups = userDto.WorkingGroups.Any() ?
                                    userDto.WorkingGroups.Select(w => new WorkingGroupResponse() { id = w.Id, Name = w.Name }).ToList()
                                    : new List<WorkingGroupResponse>()
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
                Address = userRequest.Adress,
                UrlGwl = userRequest.UrlGwl,
            };

            return user;
        }

    }
}
