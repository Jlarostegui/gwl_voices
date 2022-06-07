﻿using gwl_voices.ApplicationContracts.Services;
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




        //No funciona correctamente Revisar query
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllWorkingGroups()
        {
            List<WorkingGroupResponse> workingGroups = await _workingGroupService.GetAllWorkingGroups();
            if (workingGroups == null)
                 return NoContent();
            else
                return Ok(workingGroups);

        }


        [HttpPost]
        [Route("New")]
        [ProducesResponseType(typeof(WorkingGroupResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddNewWorkingGroup(WorkingGroupRequest workingGroup)
        {
            WorkingGroupResponse? newWorkingGroup = _workingGroupService.AddWorkingGroup(workingGroup);
            if (string.IsNullOrEmpty(newWorkingGroup.Error))
                return Ok(newWorkingGroup);
            else
                return BadRequest(newWorkingGroup.Error);

        }

        [HttpPost]
        [Route("Update")]
        [ProducesResponseType(typeof(WorkingGroupResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateWorkingGroup(WorkingGroupRequest workingGroup)
        {
            WorkingGroupResponse? uppdateworkingGrou = _workingGroupService.UpdateWorkingGroup(workingGroup);
            if (string.IsNullOrEmpty(uppdateworkingGrou.Error))
                return Ok(uppdateworkingGrou);
            else
                return BadRequest(uppdateworkingGrou.Error);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteWorkingGroup(int Id)
        {

            bool  deleteWorkingGroup = _workingGroupService.DeleteWorkingGroup(Id);
            if (deleteWorkingGroup)
                return Ok(Id);
            else
                return NoContent();

        }
    }
}
