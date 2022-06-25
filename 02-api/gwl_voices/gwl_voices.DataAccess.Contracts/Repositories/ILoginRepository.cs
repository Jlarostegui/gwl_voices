using gwl_voices.BusinessModels.Models.login;
using gwl_voices.DataAccess.Contracts.Dto;

namespace gwl_voices.DataAccess.Contracts.Repositories
{
    public interface ILoginRepository
    {
        loginResponse? login(LoginRequest login);
    }
}
