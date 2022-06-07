using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.User;
using gwl_voices.DataAccess.Contracts;
using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;

namespace gwl_voices.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _uOw;

        public UserService(IUserRepository userRepository, IUnitOfWork uOw)
        { 
            _userRepository = userRepository;
            _uOw = uOw;
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


        public UserResponse AddUser(UserRequest user)
        {
            UserDto newUser = new UserDto
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
                Adress = user.Adress,
                UrlGwl = user.UrlGwl,
            };

            UserDto userInserted = _userRepository.AddUser(newUser);

            _uOw.SaveChanges();

            UserResponse result = new UserResponse
            {
                 UserName = userInserted.Username,
                 Name = userInserted.Name,
        };

            return result;
        }
    }
}
