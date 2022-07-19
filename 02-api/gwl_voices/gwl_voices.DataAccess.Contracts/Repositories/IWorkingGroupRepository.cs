using gwl_voices.DataAccess.Contracts.Dto;

namespace gwl_voices.DataAccess.Contracts.Repositories
{
    public interface IWorkingGroupRepository
    {
        WorkingGroupDto? GetWorkingGroupById(int id);

        WorkingGroupDto? AddWorkingGroup(WorkingGroupDto workingGroup);

        Task<List<WorkingGroupDto>> GetAllWorkingGroups();

        public WorkingGroupDto? UpdateWorkingGroup(WorkingGroupDto workingGroup);

        void DeleteWorkinGroup(int id);

        List<int> getUsersOfWg(int x);

        TbiUserWgroupDto? addUserToWg(TbiUserWgroupDto tbiuserwgroup);


    }


}
