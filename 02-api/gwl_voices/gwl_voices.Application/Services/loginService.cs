using gwl_voices.Application.Contracts.Services;
using gwl_voices.BusinessModels.Models.login;
using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace gwl_voices.Application.Services
{
    public class loginService : ILoginService
    {
        private ILoginRepository _loginRepository;
        public loginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public LoginResponse? login(LoginRequest login)
        {
            UserDto? user = _loginRepository.login(login);

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

        public string GenerateToken(string username)
        {
            var header = new JwtHeader(
                new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("kjiouhvbuhvoiearhçpqvhbaUYVCCBÑDEVkLNSJDBCLLdvlmms")
                    ),
                    SecurityAlgorithms.HmacSha256)
            );

            var claims = new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.UniqueName, username),
            new Claim(ClaimTypes.Role, "admin"),
            new Claim(ClaimTypes.Role, "user"),
            };
            var payload = new JwtPayload(claims);

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
