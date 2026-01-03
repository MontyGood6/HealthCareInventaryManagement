using Healthcare.InventoryManagement.Application.DTOs;
using Healthcare.InventoryManagement.Application.Interfaces;
using Healthcare.InventoryManagement.Domain.Entity;
using Healthcare.InventoryManagement.Domain.Interfaces;

namespace Healthcare.InventoryManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;

        public AuthService(
            IUserRepository userRepository,
            ISecurityService securityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);

            if (user == null)
                return null;

            bool isValid = _securityService.VerifyPassword(
                dto.Password,
                user.PasswordHash
            );

            if (!isValid)
                return null;

            return "Login Successful";
        }

        public async Task RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
                throw new Exception("User already registered");

            var passwordHash = _securityService.HashPassword(dto.Password);

            var user = new Healthcare.InventoryManagement.Domain.Entity.User(
                Guid.NewGuid(),
                dto.Email,
                dto.Name,
                passwordHash,
                roleId: 1
            );

            await _userRepository.AddAsync(user);
        }
    }
}
