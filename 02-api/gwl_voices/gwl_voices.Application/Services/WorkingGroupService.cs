using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.WorkingGroup;
using gwl_voices.DataAccess.Contracts;
using gwl_voices.DataAccess.Contracts.Dto;
using gwl_voices.DataAccess.Contracts.Repositories;

namespace gwl_voices.Application.Services
{
    public class WorkingGroupService : IWorkingGroupService
    {
        private IWorkingGroupRepository _workingGroupRepository;
        private IUnitOfWork _uOw;

        public WorkingGroupService(IWorkingGroupRepository workingGroupRepository, IUnitOfWork uOw)
        {
            _workingGroupRepository = workingGroupRepository;
            _uOw = uOw;
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


        // No funciona , Pendite de revisar la query;
        public List<WorkingGroupResponse> GetAllWorkingGroups()
        {
            List<WorkingGroupDto> workingGroups = _workingGroupRepository.GetAllWorkingGroups();

            List<WorkingGroupResponse> response = new List<WorkingGroupResponse>();
        
            if(workingGroups != null)
            {
                response.AddRange(response);
            }

            return response;
        
        }

        public WorkingGroupResponse? AddWorkingGroup(WorkingGroupRequest workingGroup)
        {
            if (string.IsNullOrEmpty(workingGroup.Name))
                return new WorkingGroupResponse { Error = "Name is obligatory field" };

            //ToDo Verificar si el Name existe en la bbdd;

            WorkingGroupDto newWorkingGroup = new WorkingGroupDto
            {
                Name = workingGroup.Name
            };

            WorkingGroupDto workingGroupInserted = _workingGroupRepository.AddWorkingGroup(newWorkingGroup);
            _uOw.SaveChanges();

            WorkingGroupResponse response = new WorkingGroupResponse
            {
                WorkingGroupName = workingGroup.Name,
            };

            return response;

        }

        public WorkingGroupResponse? UpdateWorkingGroup(WorkingGroupRequest workingGroup)
        {
 

            WorkingGroupDto workingGroupUpdate = new WorkingGroupDto
            {
                Id = workingGroup.id, 
                Name = workingGroup.Name
            };

            WorkingGroupDto? workingGroupUpdated = _workingGroupRepository.UpdateWorkingGroup(workingGroupUpdate);
            _uOw.SaveChanges();
           


            WorkingGroupResponse response = new WorkingGroupResponse
            {
                WorkingGroupName = workingGroupUpdate.Name,
            };
            return response;
        }   

        public bool DeleteWorkingGroup(int Id)
        {
            WorkingGroupDto? workingGroup = _workingGroupRepository.GetWorkingGroupById(Id);

            if (workingGroup != null)
            {
                _workingGroupRepository.DeleteWorkinGroup(Id);
                _uOw.SaveChanges();
                return true;
            }
            else
                return false;
    
        }


    }
}
