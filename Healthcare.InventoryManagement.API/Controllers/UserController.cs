using Microsoft.AspNetCore.Mvc;
using Healthcare.InventoryManagement.Application.Services.User;
using Healthcare.InventoryManagement.Domain.Entity;

namespace Healthcare.InventoryManagement.API.Controllers
{
    [ApiController] // ✅ REQUIRED
    [Route("api/[controller]")] // ✅ REQUIRED
    public class UserController : ControllerBase // ✅ ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService; // ✅ FIX
        }

        // ✅ GET: api/user
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _userService.GetUsersAsync();
            return Ok(result);
        }

        // ✅ GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var result = await _userService.GetUserByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // ✅ POST: api/user
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await _userService.AddUserAsync(user);
            return Ok("User added successfully");
        }

        // ✅ PUT: api/user
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        // ✅ DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
