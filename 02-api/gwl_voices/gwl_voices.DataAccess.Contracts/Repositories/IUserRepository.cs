using gwl_voices.DataAccess.Contracts.Dto;

namespace gwl_voices.DataAccess.Contracts.Repositories
{
    public interface IUserRepository
    {

        UserDto? GetUserByName(string name);

        UserDto? GetUserById(int id);

        Task<List<UserDto>> GetAllUsers();

        UserDto AddUser(UserDto user);

        void DeleteUser(UserDto user);

        UserDto UpdateUser(UserDto user);
    }
}
