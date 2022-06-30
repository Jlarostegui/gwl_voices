using gwl_voices.DataAccess.Contracts.Dto;

namespace gwl_voices.DataAccess.Contracts.Repositories
{
    public interface IUserRepository
    {

        loginResponse? GetUserByName(string name);

        loginResponse? GetUserById(int id);

        Task<List<loginResponse>> GetAllUsers(int numPag, int elementPag);

        loginResponse AddUser(loginResponse user);

        void DeleteUser(loginResponse user);

        loginResponse UpdateUser(loginResponse user);

        
    }
}
