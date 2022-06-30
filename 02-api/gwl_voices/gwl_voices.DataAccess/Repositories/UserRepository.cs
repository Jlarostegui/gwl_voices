using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;
using gwl_voices.DataAccess.gwl_Context;
using gwl_voices.DataAccess.Mappers;
using Microsoft.EntityFrameworkCore;

namespace gwl_voices.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {

        private heroku_7ff63ad7795b383Context _context;

        public UserRepository(heroku_7ff63ad7795b383Context context)
        {
            _context = context;
        }

        public loginResponse? GetUserByName(string name)
        {

            var query =
                from user in _context.Users
                where user.Name == name
                select UserMapper.MapToUserDtoFromUser(user);


            return query.FirstOrDefault();
        }

        public loginResponse? GetUserById(int id)
        {
            var query =
                from user in _context.Users
                where user.Id == id
                select UserMapper.MapToUserDtoFromUser(user);

            return query.FirstOrDefault();
        }

        public async Task<List<loginResponse>> GetAllUsers(int numPag,
                                                           int elementPag)
        {
            
                try
                {
                    var query = await _context.Users
                                 .Select(u => new loginResponse
                                 {
                                     Id = u.Id,
                                     Name = u.Name,
                                     Surname = u.Surname,
                                     Password = u.Password,
                                     Username = u.Username,
                                     Adress = u.Adress,
                                     UrlGwl = u.UrlGwl,
                                     Email = u.Email,
                                     Img = u.Img,
                                     Phone = u.Phone,
                                     Rol = u.Rol,
                                     

                                 })
                                 .ToListAsync();

                    //UserDtoList result = new UserDtoList();

                    //int skip = (numPag - 1) * elementPag;

                    //result.Results =  query.Skip(skip).Take(elementPag).ToList();
                    //result.Total = query.Count();

                     return query;
                }
                catch (Exception ex)
                {
                    throw ex;
                }


        }

        public loginResponse AddUser(loginResponse user)
        {
            User newUser = UserMapper.MapToUserFromUserDto(user);

            var userInserted = _context.Users.Add(newUser);

            loginResponse result = UserMapper.MapToUserDtoFromUser(userInserted.Entity);

            return result;

         }

        public void DeleteUser(loginResponse user)
        {
            User userToDelete = UserMapper.MapToUserFromUserDto(user);
            _context.Users.Remove(userToDelete);
        }


        public loginResponse UpdateUser(loginResponse user)
        {
            User userToUpdate = UserMapper.MapToUserFromUserDto(user);

            var userUpdated = _context.Users.Update(userToUpdate);

            loginResponse result = UserMapper.MapToUserDtoFromUser(userUpdated.Entity);
            return result;

        }
    }


}
