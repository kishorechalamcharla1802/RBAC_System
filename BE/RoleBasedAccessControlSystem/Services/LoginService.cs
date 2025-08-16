using Microsoft.IdentityModel.Tokens;
using RoleBasedAccessControlSystem.Dto;
using RoleBasedAccessControlSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace RoleBasedAccessControlSystem.Services
{
    public class LoginService : ILoginService
    {
        private IConfiguration _config;
        private IUserRolesService _userRolesService;

        public LoginService(IConfiguration config, IUserRolesService userRolesService)
        {
            _config = config;
            _userRolesService = userRolesService;
        }

        public LoginResponseDto UserAuthenticate(LoginRequest user)
        {
            if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                return new LoginResponseDto { IsSuccess = false, Token = null, Message = "User credentials are Empty" };
            }

            List<User> users = _userRolesService.GetAllUsers(); // Fetch all users and roles
            var authenticatedUser = users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            var userInfo = new UserInfo
            {
                Id = authenticatedUser.Id,
                Username = authenticatedUser.Username,
                Role = authenticatedUser.Role
            };
            if (authenticatedUser == null)
                return new LoginResponseDto { IsSuccess = false, Token = null, Message = "Invalid user credentials", UserData = null }; //Invalid user credentials

            var token = GenerateJwtToken(authenticatedUser); // Generate JWT token for the user
            return new LoginResponseDto { IsSuccess = true, Token = token, Message = "Login successfull", UserData =  userInfo}; // User authenticated successfully

        }

        public string GenerateJwtToken(User user)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role) // Assigning a role to the user
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
