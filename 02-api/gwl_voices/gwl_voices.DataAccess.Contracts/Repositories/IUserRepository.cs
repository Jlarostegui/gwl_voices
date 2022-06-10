using gwl_voices.DataAccess.Contracts.Dto;

namespace gwl_voices.DataAccess.Contracts.Repositories
{
    public interface IUserRepository
    {

        UserDto? GetUserByName(string name);

        UserDto? GetUserById(int id);

        UserDto AddUser(UserDto user);

        void DeleteUser(UserDto user);

        UserDto UpdateUser(UserDto user);
    }
}
