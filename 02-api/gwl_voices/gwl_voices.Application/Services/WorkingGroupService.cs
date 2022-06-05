using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.WorkingGroup;
using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;
using gwl_voices.DataAccess.Repositories;

namespace gwl_voices.Application.Services
{
    public class WorkingGroupService : IWorkingGroupService
    {
        private IWorkingGroupRepository _workingGroupRepository;

        public WorkingGroupService(IWorkingGroupRepository workingGroupRepository)
        {
            _workingGroupRepository = workingGroupRepository;
        }

        public WorkingGroupResponse? GetWorkingGroupById(int id)
        {
            WorkingGroupDto? workingGroup = _workingGroupRepository.GetWorkingGroupById(id);

            WorkingGroupResponse? response = new WorkingGroupResponse();

            if (workingGroup != null)
            {
                response.WorkingGroupName = workingGroup.Name;
            }

            return response;
        }
    }
}
