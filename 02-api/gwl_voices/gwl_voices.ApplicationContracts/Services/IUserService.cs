using gwl_voices.BusinessModels.Models.User;

namespace gwl_voices.ApplicationContracts.Services
{
    public interface IUserService
    {

        UserResponse? GetUserByName(string name);

        UserResponse? GetUserById(int id);

        Task<List<UserResponse>> GetAllUsers();
        UserResponse AddUser(UserRequest user);

        bool DeleteUser(int id);

        UserResponse UpdateUser(UserUpdateRequest user, int id);
    }
}
