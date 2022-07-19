namespace gwl_voices.DataAccess.gwl_Context
{
    public partial class TbiUserWgroup
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkingGrId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual WorkingGroup WorkingGr { get; set; } = null!;
    }
}
