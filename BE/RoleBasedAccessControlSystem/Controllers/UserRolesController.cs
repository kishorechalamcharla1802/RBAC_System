using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoleBasedAccessControlSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        public UserRolesController()
        {
            // Constructor logic can be added here if needed
        }

        [HttpGet]
        [Route("GetUserRoles")]
        [Authorize(Roles = "Admin,Editor,Viewer")]
        public IActionResult GetUsersAndRoles()
        {
            // This method can be used to retrieve user roles
            return Ok("List of user roles");
        }

        [HttpPost]
        [Route("AddUserRoles")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddUsersAndRoles()
        {
            // This method can be used to retrieve user roles
            return Ok("roles added.");
        }
    }
}
