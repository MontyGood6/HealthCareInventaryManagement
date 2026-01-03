using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.InventoryManagement.Application.Interfaces.User
{
    internal interface IUserServices
    {
        public Task<List<Domain.Entity.User>> GetUsersAsync();
        public Task<Domain.Entity.User?> GetUserByIdAsync(Guid id);
        public Task AddUserAsync(Domain.Entity.User user);
        public Task UpdateUserAsync(Domain.Entity.User user);
        public Task DeleteUserAsync(Guid id);

    }
}
