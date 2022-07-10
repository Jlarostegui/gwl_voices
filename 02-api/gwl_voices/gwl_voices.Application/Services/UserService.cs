using gwl_voices.Application.Mappers;
using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.User;
using gwl_voices.BusinessModels.Models.WorkingGroup;
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
        public async Task<UserResponse?> GetUserByName(string name)
        {
            UserDto? user = await _userRepository.GetUserByName(name);

            UserResponse result = new UserResponse();

            if (user != null)
            {
                result = UserMapper.MapToUserResponseFromUserDto(user);
            }
            else return null;
            return result;


        }

        public async Task<UserResponse?> GetUserById(int id)
        {
            UserDto? user = await _userRepository.GetUserById(id);

            UserResponse result = new UserResponse();
            if (user != null)
            {
                result = UserMapper.MapToUserResponseFromUserDto(user);
            }
            else return null;
            return result;
        }


        public async Task<UserListResponse> GetAllUsers(int numPag, int elementPag)
        {
            var response = new UserListResponse();

            try
            {
                var result = await _userRepository.GetAllUsers(numPag, elementPag);
                foreach (var user in result.Results)
                {
                    var uResponse = new UserResponse
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Surname = user.Surname,
                        Password = user.Password,
                        Username = user.Username,
                        Adress = user.Address,
                        UrlGwl = user.UrlGwl,
                        Email = user.Email,
                        Img = user.Img,
                        Phone = user.Phone,
                        Rol = user.Rol,
                        WorkingGroups = user.WorkingGroups.Any() ?
                                    user.WorkingGroups.Select(w => new WorkingGroupResponse() { id = w.Id, Name = w.Name }).ToList()
                                    : new List<WorkingGroupResponse>()
                    };

                    response.Results.Add(uResponse);
                }

                response.Total = result.Total;
                return response;

            }


            catch (Exception oException)
            {
                throw oException;
            }
        }


        public UserResponse AddUser(UserRequest user)
        {
            if (string.IsNullOrEmpty(user.Username)
            || string.IsNullOrEmpty(user.Password)
            || string.IsNullOrEmpty(user.Rol)
            || string.IsNullOrEmpty(user.Name)
            || string.IsNullOrEmpty(user.Surname)
            || string.IsNullOrEmpty(user.Email)
            || string.IsNullOrEmpty(user.Img)
            || string.IsNullOrEmpty(user.Phone)
            || string.IsNullOrEmpty(user.Address)
            || string.IsNullOrEmpty(user.UrlGwl)
            ) return new UserResponse { Error = "Todos los campos son obligatorios" };

            UserDto newUser = UserMapper.MapToUserDtoFromUserRequest(user);

            UserDto userInserted = _userRepository.AddUser(newUser);

            _uOw.SaveChanges();

            UserResponse result = UserMapper.MapToUserResponseFromUserDto(userInserted);
            return result;
        }


        public async Task<bool> DeleteUser(int id)
        {
            UserDto? user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return false;
            }
            else
            {
                _userRepository.DeleteUser(user);

                _uOw.SaveChanges();
                return true;

            }
        }

        public async Task<UserResponse> UpdateUser(UserUpdateRequest user, int id)
        {
            if (id == 0)
                return new UserResponse { Error = "El id del usuario no puede ser 0" };

            if (string.IsNullOrEmpty(user.Username)
            || string.IsNullOrEmpty(user.Password)
            || string.IsNullOrEmpty(user.Rol)
            || string.IsNullOrEmpty(user.Name)
            || string.IsNullOrEmpty(user.Surname)
            || string.IsNullOrEmpty(user.Email)
            || string.IsNullOrEmpty(user.Img)
            || string.IsNullOrEmpty(user.Phone)
            || string.IsNullOrEmpty(user.Adress)
            || string.IsNullOrEmpty(user.UrlGwl)
            ) return new UserResponse { Error = "Todos los campos son obligatorios" };

            UserDto? existingUser = await _userRepository.GetUserById(id);

            if (existingUser == null)
                return new UserResponse { Error = "El usuario no existe en BBDD" };


            UserDto newUser = new UserDto
            {
                Id = id,
                Username = user.Username,
                Password = user.Password,
                Rol = user.Rol,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Img = user.Img,
                Phone = user.Phone,
                Address = user.Adress,
                UrlGwl = user.UrlGwl,
            };


            UserDto userUpdated =  _userRepository.UpdateUser(newUser);

            _uOw.SaveChanges();

            UserResponse result = UserMapper.MapToUserResponseFromUserDto(userUpdated);

            return result;
        }

    }
}
