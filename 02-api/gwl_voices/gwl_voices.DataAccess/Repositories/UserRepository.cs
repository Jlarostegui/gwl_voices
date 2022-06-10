using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;
using gwl_voices.DataAccess.gwl_Context;
using gwl_voices.DataAccess.Mappers;

namespace gwl_voices.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {

        private heroku_7ff63ad7795b383Context _context;

        public UserRepository(heroku_7ff63ad7795b383Context context)
        {
            _context = context;
        }

        public UserDto? GetUserByName(string name)
        {

            var query =
                from user in _context.Users
                where user.Name == name
                select UserMapper.MapToUserDtoFromUser(user);


            return query.FirstOrDefault();
        }

        public UserDto? GetUserById(int id)
        {
            var query =
                from user in _context.Users
                where user.Id == id
                select UserMapper.MapToUserDtoFromUser(user);

            return query.FirstOrDefault();
        }

        public UserDto AddUser(UserDto user)
        {
            User newUser = UserMapper.MapToUserFromUserDto(user);

            var userInserted = _context.Users.Add(newUser);

            UserDto result = UserMapper.MapToUserDtoFromUser(userInserted.Entity);

            return result;

         }

        public void DeleteUser(UserDto user)
        {
            User userToDelete = UserMapper.MapToUserFromUserDto(user);
            _context.Users.Remove(userToDelete);
        }


        public UserDto UpdateUser(UserDto user)
        {
            User userToUpdate = UserMapper.MapToUserFromUserDto(user);

            var userUpdated = _context.Users.Update(userToUpdate);

            UserDto result = UserMapper.MapToUserDtoFromUser(userUpdated.Entity);
            return result;

        }
    }


}
