using gwl_voices.DataAccess.Contracts.Dto;

namespace gwl_voices.DataAccess.Contracts.Repositories
{
    public interface IUserRepository
    {

        Task<UserDto?> GetUserByName(string name);

        Task<UserDto?> GetUserById(int id);

        Task<UserDtoList> GetAllUsers(int numPag, int elementPag);

        UserDto AddUser(UserDto user);
            
        void DeleteUser(UserDto user);

        UserDto UpdateUser(UserDto user);

    }
}
