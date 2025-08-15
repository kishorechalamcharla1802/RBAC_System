using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAccessControlSystem.Models;
using RoleBasedAccessControlSystem.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoleBasedAccessControlSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService; 
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult LoginUser([FromBody] LoginRequest user)
        {
            IActionResult response = Unauthorized();
            var loginResponse = _loginService.UserAuthenticate(user);
            if(loginResponse != null && loginResponse.IsSuccess ==true)
            {
                response = Ok(loginResponse);
            }
            else
            {
                response = Unauthorized(loginResponse);
            }
            return response;
        }
    }
}
