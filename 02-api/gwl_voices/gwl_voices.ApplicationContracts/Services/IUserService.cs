using gwl_voices.BusinessModels.Models.User;

namespace gwl_voices.ApplicationContracts.Services
{
    public interface IUserService
    {
        Task<UserResponse?> GetUserByName(string name);

        Task<UserResponse?> GetUserById(int id);

        Task<UserListResponse> GetAllUsers(int numPag, int elementPag);
        UserResponse AddUser(UserRequest user);

        Task<bool> DeleteUser(int id);

        Task<UserResponse> UpdateUser(UserUpdateRequest user, int id);
    }
}
