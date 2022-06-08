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
                response.WgId = workingGroup.Id;
            }

            return response;
        }

        public async Task<List<WorkingGroupResponse>> GetAllWorkingGroups()
        {
            var response = new List<WorkingGroupResponse>();
            try
            {
                var workingGroups = await _workingGroupRepository.GetAllWorkingGroups();
                foreach (var workingGroup in workingGroups)
                {
                    var wkresponse = new WorkingGroupResponse
                    {
                        WorkingGroupName = workingGroup.Name,
                        WgId = workingGroup.Id,

                    };

                    response.Add(wkresponse);
                }


                return response;
            }
            catch (Exception oException)
            {
                throw oException;
            }


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

