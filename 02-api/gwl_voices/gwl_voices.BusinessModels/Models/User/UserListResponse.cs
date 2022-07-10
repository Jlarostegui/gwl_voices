namespace gwl_voices.BusinessModels.Models.User
{
    public class UserListResponse: BaseResponse
    {

        public List<UserResponse> Results { get; set; }
        public int Total { get; set; }

        public UserListResponse()
        {
            Results = new List<UserResponse>();
        }
    }
}
