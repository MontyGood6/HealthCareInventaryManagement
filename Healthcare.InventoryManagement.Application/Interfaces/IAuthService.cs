
using Healthcare.InventoryManagement.Application.DTOs;

namespace Healthcare.InventoryManagement.Application.Interfaces
{
    // Application/Interfaces/IAuthService.cs
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
    }

}
