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
            loginResponse? user = _loginRepository.login(login);

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
            var secret_key = Encoding.ASCII.GetBytes("kjiouhvbuhvoiearhçpqvhbaUYVCCBÑDEVkLNSJDBCLLdvlmms");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret_key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            if (token == null)
                return false;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("kjiouhvbuhvoiearhçpqvhbaUYVCCBÑDEVkLNSJDBCLLdvlmms");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                if (userId != 0)
                    return true;
                else
                    return false; 
            }
            catch
            {
                return false;
            }
        }
    }
}
