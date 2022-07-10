using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.gwl_Context;

namespace gwl_voices.DataAccess.Mappers
{
    public static class UserMapper
    {
        public static UserDto MapToUserDtoFromUser(User user)
        {
            UserDto result = new UserDto

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
                Address = user.Adress,
                UrlGwl = user.UrlGwl,
                WorkingGroups = (user.TbiUserWgroups.Any()) ?
                                user.TbiUserWgroups.Select(w => new WorkingGroupDto { Id = w.WorkingGr.Id, Name = w.WorkingGr.Name }).ToList()
                                : new List<WorkingGroupDto>(),
            };

            return result;
        }

        public static User MapToUserFromUserDto(UserDto userDto)
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
                Adress = userDto.Address,
                UrlGwl = userDto.UrlGwl,
            };

            return user;
        }

        public static UserDtoList MapToUserDtoListFromUserDto(UserDto userDto)
        {
            UserDtoList result = new UserDtoList
            {
                
            };

            return result;
        }


    }
}
