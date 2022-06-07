using gwl_voices.DataAccess.Contracts.Dto;

namespace gwl_voices.DataAccess.Contracts.Repositories
{
    public interface IUserRepository
    {

        UserDto? GetUserByName(string name);

        UserDto AddUser(UserDto user);
    }
}
