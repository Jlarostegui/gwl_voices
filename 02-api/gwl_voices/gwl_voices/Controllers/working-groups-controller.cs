using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.TbiUserWg;
using gwl_voices.BusinessModels.Models.WorkingGroup;
using Microsoft.AspNetCore.Mvc;

namespace gwl_voices.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class working_groupscontroller : Controller
    {

        private IWorkingGroupService _workingGroupService;

        public working_groupscontroller(IWorkingGroupService workingGroupService)
        {
           _workingGroupService = workingGroupService;
        }
    
        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public IActionResult GetWorkingGroupById(int id)
        {
            WorkingGroupResponse? workingGroup = _workingGroupService.GetWorkingGroupById(id);

            if (workingGroup != null)
            {
                return Ok(workingGroup);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllWorkingGroups()
        {
            List<WorkingGroupResponse> workingGroups = await _workingGroupService.GetAllWorkingGroups();
            if (workingGroups == null)
                 return NoContent();
            else
                return Ok(workingGroups);

        }


        [HttpPost]
        [Authorize]
        public IActionResult AddNewWorkingGroup(WorkingGroupRequest workingGroup)
        {
            WorkingGroupResponse? newWorkingGroup = _workingGroupService.AddWorkingGroup(workingGroup);
            if (string.IsNullOrEmpty(newWorkingGroup.Error))
                return Ok(newWorkingGroup);
            else
                return BadRequest(newWorkingGroup.Error);

        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateWorkingGroup(WorkingGroupRequest workingGroup)
        {
            WorkingGroupResponse? uppdateworkingGrou = _workingGroupService.UpdateWorkingGroup(workingGroup);
            if (string.IsNullOrEmpty(uppdateworkingGrou.Error))
                return Ok(uppdateworkingGrou);
            else
                return BadRequest(uppdateworkingGrou.Error);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id}")]
        public IActionResult DeleteWorkingGroup(int id)
        {

            bool  deleteWorkingGroup = _workingGroupService.DeleteWorkingGroup(id);
            if (deleteWorkingGroup)
                return Ok(id);
            else
                return NoContent();

        }

        [HttpGet]
        [Authorize]
        [Route("get/{id}")]
        public IActionResult getUsersOfWg(int id)
        {
            List<int> users = _workingGroupService.getUsersOfWg(id);
            return Ok(users);
        }

        [HttpPost]
        [Authorize]
        [Route("add/usertbi")]
        public IActionResult addUserToWg(TbiUserWgRequest tbiuserwgroup)
        {
            _workingGroupService.addUserToWg(tbiuserwgroup);
            return Ok();
        }
    }
}
