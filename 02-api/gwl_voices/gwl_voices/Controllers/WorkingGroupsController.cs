using gwl_voices.ApplicationContracts.Services;
using gwl_voices.BusinessModels.Models.WorkingGroup;
using Microsoft.AspNetCore.Mvc;

namespace gwl_voices.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WorkingGroupsController : Controller
    {

        private IWorkingGroupService _workingGroupService;

        public WorkingGroupsController(IWorkingGroupService workingGroupService)
        {
           _workingGroupService = workingGroupService;
        }

        [HttpGet]
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
    }
}
