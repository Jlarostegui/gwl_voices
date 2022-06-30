using gwl_voices.BusinessModels.Models.login;
using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;
using gwl_voices.DataAccess.Mappers;

namespace gwl_voices.DataAccess.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private heroku_7ff63ad7795b383Context _context;
        public LoginRepository(heroku_7ff63ad7795b383Context context)
        {
            _context = context;
        }

        public LoginResponse? login(LoginRequest login)
        {
            var query =
                from user in _context.Users
                where user.Username ==  login.user && user.Password == login.password
                select new LoginResponse
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

       

    }


}
