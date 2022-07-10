using gwl_voices.BusinessModels.Models.WorkingGroup;

namespace gwl_voices.BusinessModels.Models.User
{
    public class UserResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Img { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string UrlGwl { get; set; } = null!;
        public List<WorkingGroupResponse> WorkingGroups { get; set; } = new List<WorkingGroupResponse>();
    }
}
