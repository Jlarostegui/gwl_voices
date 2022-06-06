using gwl_voices.BusinessModels.Models.User;

namespace gwl_voices.ApplicationContracts.Services
{
    public interface IUserService
    {

        UserResponse? GetUserByName(string name);
    }
}
