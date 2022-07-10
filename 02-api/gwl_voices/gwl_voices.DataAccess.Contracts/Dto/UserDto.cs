namespace gwl_voices.DataAccess.Contracts.Dto
{
    public class UserDto
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
        public string Address { get; set; } = null!;
        public string UrlGwl { get; set; } = null!;        
        public List<WorkingGroupDto> WorkingGroups { get; set; } = new List<WorkingGroupDto>();
        
    }
}
 