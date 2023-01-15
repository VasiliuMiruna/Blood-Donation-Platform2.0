using blood_donation_backend.blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blood_donation_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MedicineModel medicine)
        {
            _medicineService.Create(medicine);
            return Ok(medicine);
        }

        [HttpGet]
        public async Task<List<MedicineModel>> GetMedicines()
        {
            var medicines = await _medicineService.GetAll();
            return medicines;
        }
    }
}
