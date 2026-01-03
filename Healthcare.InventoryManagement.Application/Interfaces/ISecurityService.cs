using Healthcare.InventoryManagement.Domain.Entity;

namespace Healthcare.InventoryManagement.Application.Interfaces
{
    public interface ISecurityService
    {
        string HashPassword(string password);

        bool VerifyPassword(string password, string hashedPassword);

        
    }
}
