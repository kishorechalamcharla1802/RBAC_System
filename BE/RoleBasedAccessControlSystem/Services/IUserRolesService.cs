using RoleBasedAccessControlSystem.Models;

namespace RoleBasedAccessControlSystem.Services
{
    public interface IUserRolesService
    {
        List<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}
