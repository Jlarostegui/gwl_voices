using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;

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
                from u in _context.Users
                where u.Name == name
                select new UserDto
                {

                    Id = u.Id,
                    Username = u.Username,
                    Password = u.Password,
                    Rol = u.Rol,
                    Name = u.Name, 
                    Surname = u.Surname,
                    Email = u.Email,
                    Img = u.Img,
                    Phone = u.Phone,
                    Adress = u.Adress,
                    UrlGwl = u.UrlGwl,


                };


            return query.FirstOrDefault();
        }
    }
}
