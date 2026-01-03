using Healthcare.InventoryManagement.Application.Interfaces.User;
using Healthcare.InventoryManagement.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Healthcare.InventoryManagement.Application.Services.User
{
    public class IUserService : IUserServices
    {
        
        private readonly IUserRepository _userRepository;
        private readonly IMemoryCache _cache;


        public IUserService(IUserRepository userRepository, IMemoryCache cache)
        {
            _userRepository = userRepository;
            _cache = cache;
        }   

        public async Task AddUserAsync(Domain.Entity.User user)
        {
           await _userRepository.AddAsync(user);
            _cache.Remove("users_all");


        }

        public Task DeleteUserAsync(Guid id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public async Task<Domain.Entity.User?> GetUserByIdAsync(Guid id)
        {
             string cacheKey = $"user_{id}";

            if(!_cache.TryGetValue(cacheKey,out Domain.Entity.User? user))
            {

                user = await _userRepository.GetByIdAsync(id);

                if(user != null)
                {
                    _cache.Set(cacheKey,
                        user,
                        TimeSpan.FromMinutes(5)
                    );
                }

               
            }


            return user;


        }

        public async Task<List<Domain.Entity.User>> GetUsersAsync()
        {
            const string cacheKey = "userList";

            if (!_cache.TryGetValue(cacheKey, out List<Domain.Entity.User> userList))
            {
                userList = await _userRepository.GetAllAsync();

                _cache.Set(
                    cacheKey,
                    userList,
                    TimeSpan.FromMinutes(5)
                );
            }

            return userList;
        }


        public Task UpdateUserAsync(Domain.Entity.User user)
        {
            return _userRepository.UpdateAsync(user);
        }
    }
}
