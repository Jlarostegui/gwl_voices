using gwl_voices.BusinessModels.Models.login;

namespace gwl_voices.Application.Contracts.Services
{
    public interface ILoginService
    {
        LoginResponse? login(LoginRequest login);

        string GenerateToken(string username);
    }

}
