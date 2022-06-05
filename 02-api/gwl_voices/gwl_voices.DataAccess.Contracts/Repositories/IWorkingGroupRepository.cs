using gwl_voices.DataAccess.Contracts.Dto;

namespace gwl_voices.DataAccess.Contracts.Repositories
{
    public interface IWorkingGroupRepository
    {
        WorkingGroupDto GetWorkingGroupById(int id);
    }
}
