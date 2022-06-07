namespace gwl_voices.DataAccess.Contracts.Dto
{
    public class WorkingGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public static implicit operator List<object>(WorkingGroupDto v)
        {
            throw new NotImplementedException();
        }
    }
}
