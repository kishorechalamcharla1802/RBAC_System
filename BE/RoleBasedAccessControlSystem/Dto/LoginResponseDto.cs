using RoleBasedAccessControlSystem.Models;

namespace RoleBasedAccessControlSystem.Dto
{
    public class LoginResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public UserInfo UserData { get; set; }
    }
}
