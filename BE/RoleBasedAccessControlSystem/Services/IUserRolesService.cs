using RoleBasedAccessControlSystem.Models;

namespace RoleBasedAccessControlSystem.Services
{
    public interface IUserRolesService
    {
        List<UserInfo> GetAllUsersInfo();
        List<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(UserInfo user);
        void DeleteUser(int userId);
    }
}
