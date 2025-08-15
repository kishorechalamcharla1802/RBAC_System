using RoleBasedAccessControlSystem.Dto;
using RoleBasedAccessControlSystem.Models;

namespace RoleBasedAccessControlSystem.Services
{
    public interface ILoginService
    {
        LoginResponseDto UserAuthenticate(LoginRequest user);

        string GenerateJwtToken(User user);
    }
}
