using gwl_voices.BusinessModels.Models.login;
using gwl_voices.BusinessModels.Models.User;

namespace gwl_voices.Application.Contracts.Services
{
    public interface ILoginService
    {
        LoginResponse? login(LoginRequest login);

        string GenerateToken(LoginResponse user);

        int? ValidateToken(string token);
    }

}
