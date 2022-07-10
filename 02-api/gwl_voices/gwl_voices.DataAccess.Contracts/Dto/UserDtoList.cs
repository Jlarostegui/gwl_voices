namespace gwl_voices.DataAccess.Contracts.Dto
{
    public class UserDtoList
    {

        public List<UserDto> Results { get; set; }
        public int Total { get; set; }

        public UserDtoList()
        {
            Results = new List<UserDto>();
        }
    }
}
