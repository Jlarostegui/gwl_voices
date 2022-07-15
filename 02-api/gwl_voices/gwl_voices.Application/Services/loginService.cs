using gwl_voices.Application.Contracts.Services;
using gwl_voices.Application.Mappers;
using gwl_voices.BusinessModels.Models.login;
using gwl_voices.BusinessModels.Models.User;
using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace gwl_voices.Application.Services
{
    public class loginService : ILoginService
    {
        private ILoginRepository _loginRepository;
        private IConfiguration _configuration;
        private IUserRepository _userRepository;

        private ImailService _mailService;

        public loginService(ILoginRepository loginRepository, IConfiguration configuration, ImailService mailService)
        {
            _loginRepository = loginRepository;
            _configuration = configuration;
            _mailService = mailService;
        }

        public LoginResponse? login(LoginRequest login)
        {
            LoginResponse? user = _loginRepository.login(login);

            LoginResponse result = new LoginResponse();

            if (user != null)
            {
                result.Name = user.Name;
                result.Id = user.Id;
                result.Username = user.Username;
                result.Password = user.Password;
                result.Rol = user.Rol;
                result.Name = user.Name;
                result.Surname = user.Surname;
                result.Email = user.Email;
                result.Img = user.Img;
                result.Phone = user.Phone;
                result.Adress = user.Adress;
                result.UrlGwl = user.UrlGwl;
            }
            else return null;
            return result;

        }


        public string GenerateToken(LoginResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration.GetSection("AppSettings").GetSection("Secret");
            var key = Encoding.ASCII.GetBytes(secret.Value);

            var secret_key = Encoding.ASCII.GetBytes(secret.Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret_key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
