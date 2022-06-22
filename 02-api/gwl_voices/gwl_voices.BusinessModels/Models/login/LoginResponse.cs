using gwl_voices.BusinessModels.Models.User;

namespace gwl_voices.BusinessModels.Models.login
{
    public class LoginResponse : UserResponse
    {
       public string? token { get; set; } = null;
    }
}
