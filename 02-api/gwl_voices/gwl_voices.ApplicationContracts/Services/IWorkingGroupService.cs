using gwl_voices.BusinessModels.Models.WorkingGroup;

namespace gwl_voices.ApplicationContracts.Services
{
    public interface IWorkingGroupService
    {
        WorkingGroupResponse GetWorkingGroupById(int id);
    }
}
