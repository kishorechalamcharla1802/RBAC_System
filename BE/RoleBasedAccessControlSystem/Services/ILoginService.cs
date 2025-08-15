using RoleBasedAccessControlSystem.Dto;
using RoleBasedAccessControlSystem.Models;

namespace RoleBasedAccessControlSystem.Services
{
    public interface ILoginService
    {
        LoginResponseDto UserAuthenticate(User user);

        string GenerateJwtToken(User user);
    }
}
