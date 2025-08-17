using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAccessControlSystem.Models;
using RoleBasedAccessControlSystem.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoleBasedAccessControlSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupStepsController : ControllerBase
    {
        private ISetupStepsService  _setupStepsService;

        public SetupStepsController(ISetupStepsService setupStepsService)
        {
            _setupStepsService = setupStepsService;
        }

        [HttpGet]
        [Route("GetSetupSteps")]
        [Authorize(Roles = "Admin,Editor,Viewer")]
        public IActionResult GetSetupSteps()
        {
           var result = _setupStepsService.GetAllSetupSteps();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddStep")]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult AddSetupStep([FromBody] SetupStep steps)
        {
            _setupStepsService.AddSetupStep(steps);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateStep")]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult UpdateSetupStep([FromBody] SetupStep value)
        {
            _setupStepsService.UpdateSetupStep(value);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteSetupStep/{stepNo:int}")]
        [Authorize(Roles = "Admin,Editor")]
        public IActionResult DeleteSetupStep(int stepNo)
        {
            if (stepNo <= 0)
            {
                return BadRequest("Invalid step number.");
            }
            _setupStepsService.DeleteSetupStep(stepNo);
            return Ok();
        }
    }
}
