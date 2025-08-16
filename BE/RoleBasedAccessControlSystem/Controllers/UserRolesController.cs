using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAccessControlSystem.Models;
using RoleBasedAccessControlSystem.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoleBasedAccessControlSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        IUserRolesService _userRolesService;
        public UserRolesController(IUserRolesService userRolesService)
        {
            _userRolesService = userRolesService;
        }

        [HttpGet]
        [Route("GetUser")]
        [Authorize(Roles = "Admin,Editor,Viewer")]
        public IActionResult GetUsersAndRoles()
        {

            var result = _userRolesService.GetAllUsersInfo();

            return Ok(result);
        }

        [HttpPost]
        [Route("AddUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddUsersAndRoles([FromBody] User user)
        {
            _userRolesService.AddUser(user);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateUsersAndRoles([FromBody] UserInfo user)
        {
            _userRolesService.UpdateUser(user);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser/{userId:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUsersAndRoles(int userId)
        {
            _userRolesService.DeleteUser(userId);
            return Ok();
        }
    }
}
