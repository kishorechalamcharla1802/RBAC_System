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
            //IActionResult result = null;

            var result = _userRolesService.GetAllUsers();

            return Ok(result);
        }

        [HttpPost]
        [Route("AddUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddUsersAndRoles([FromBody] User user)
        {
            _userRolesService.AddUser(user);
            // This method can be used to retrieve user roles
            return Ok("user added.");
        }

        [HttpPut]
        [Route("UpdateUser")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateUsersAndRoles([FromBody] User user)
        {
            _userRolesService.UpdateUser(user);
            // This method can be used to retrieve user roles
            return Ok("user updated.");
        }

        [HttpDelete]
        [Route("DeleteUser/{userId:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUsersAndRoles(int userId)
        {
            _userRolesService.DeleteUser(userId);
            // This method can be used to retrieve user roles
            return Ok("user deleted.");
        }
    }
}
