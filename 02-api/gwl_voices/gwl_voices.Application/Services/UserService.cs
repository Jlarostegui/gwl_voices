using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.User;
using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;

namespace gwl_voices.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        { 
            _userRepository = userRepository;
        }
        public UserResponse? GetUserByName(string name)
        {
            UserDto? user = _userRepository.GetUserByName(name);

            UserResponse result = new UserResponse();

            if (user != null)
            {
                result.UserName = user.Username;
                result.Name = user.Name;
            }
            else return null;
            return result;

           
        }
    }
}
