using Healthcare.InventoryManagement.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.InventoryManagement.API.Controllers
{
    [ApiController]
    [Route("api/medicines")]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _service;

        public MedicineController(IMedicineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedicine()
        {
            var medicines = await _service.GetMedicinesAsync();

            // DB empty ho to [] return hoga
            return Ok(medicines);
        }



    }
    
}
