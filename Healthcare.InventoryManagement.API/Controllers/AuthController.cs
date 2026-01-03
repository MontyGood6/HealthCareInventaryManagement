using Healthcare.InventoryManagement.Application.DTOs;
using Healthcare.InventoryManagement.Application.Interfaces;
using Healthcare.InventoryManagement.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Healthcare.InventoryManagement.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _authService.RegisterAsync(dto);
            return Ok("User registered successfully");
        }
        [HttpPost("login")]


        public async Task<IActionResult> Login(LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            if (token == null)
                return Unauthorized("Invalid credentials");
            return Ok(new { Token = token });


        }


        [Authorize(Roles = "Admin")]
        [HttpPost("medicine")]
        public IActionResult AddMedicine(Medicine med)
        {
            return Ok();
        }



        [Authorize(Roles = "Admin,Doctor")]
        [HttpGet("medicine")]
        public IActionResult GetMedicines()
        {
            return Ok();
        }


    }
}

