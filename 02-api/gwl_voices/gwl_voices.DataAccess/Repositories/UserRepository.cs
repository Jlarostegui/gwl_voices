using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;
using gwl_voices.DataAccess.gwl_Context;

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
                select new UserDto
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


            return query.FirstOrDefault();
        }

        public UserDto AddUser(UserDto user)
        {
            User newUser = new User
            {
              
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

            var userInserted = _context.Users.Add(newUser);

            UserDto result = new UserDto

            {
                Id = userInserted.Entity.Id,
                Username = userInserted.Entity.Username,
                Password = userInserted.Entity.Password,
                Rol = userInserted.Entity.Rol,
                Name = userInserted.Entity.Name,
                Surname = userInserted.Entity.Surname,
                Email = userInserted.Entity.Email,
                Img = userInserted.Entity.Img,
                Phone = userInserted.Entity.Phone,
                Adress = userInserted.Entity.Adress,
                UrlGwl = userInserted.Entity.UrlGwl,
            };

            return result;

         }



     }


}
