using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAccessControlSystem.Models;
using System.Text.Json;

namespace RoleBasedAccessControlSystem.Services
{
    public class UserRolesService : IUserRolesService
    {
        private readonly string _filePath = "users.json";

        public List<User> GetAllUsers()
        {
            if (!File.Exists(_filePath)) return new List<User>();

            var json = File.ReadAllText(_filePath);
            var users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            return users;
        }

        public void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user), "Request body cannot be null.");
            var users = GetAllUsers();
            user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            users.Add(user);
            SaveUsers(users);
        }

        public void UpdateUser(User user)
        {
            var users = GetAllUsers();
            User? existingUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Role = user.Role;
                SaveUsers(users);
            }
            else
            {
                throw new KeyNotFoundException($"User with ID {user.Id} not found.");
            }
        }

        public void DeleteUser(int userId)
        {
            var users = GetAllUsers();
            User? existingUser = users.FirstOrDefault(u => u.Id == userId);
            if(existingUser != null)
            {
                users.Remove(existingUser);
                SaveUsers(users);
            }
            
        }

        private void SaveUsers(List<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        
    }
}
