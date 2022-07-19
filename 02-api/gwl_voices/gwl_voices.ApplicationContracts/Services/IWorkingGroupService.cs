using gwl_voices.BusinessModels.Models.TbiUserWg;
using gwl_voices.BusinessModels.Models.WorkingGroup;

namespace gwl_voices.ApplicationContracts.Services
{
    public interface IWorkingGroupService 
    {
        WorkingGroupResponse GetWorkingGroupById(int id);
        Task<List<WorkingGroupResponse>> GetAllWorkingGroups();
        WorkingGroupResponse? AddWorkingGroup(WorkingGroupRequest workingGroup);
        WorkingGroupResponse? UpdateWorkingGroup(WorkingGroupRequest workingGroup);
        bool DeleteWorkingGroup(int Id);
        List<int> getUsersOfWg(int x);
        void addUserToWg(TbiUserWgRequest tbiuserwgroup);
    }
}
