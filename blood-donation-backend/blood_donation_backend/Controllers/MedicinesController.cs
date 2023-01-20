using blood_donation_backend.blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin,Doctor")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MedicineModel medicine)
        {
            await _medicineService.Create(medicine);
            return Ok(medicine);
        }

        [Authorize(Roles = "Admin,Doctor")]
        [HttpGet]
        public async Task<List<MedicineModel>> GetMedicines()
        {
            var medicines = await _medicineService.GetAll();
            return medicines;
        }

        [Authorize(Roles = "Admin,Doctor")]
        [HttpGet("{id}")]
        public async Task<MedicineModel> GetMedicineById([FromRoute] Guid id)
        {
            var medicine = await _medicineService.GetById(id);
            return medicine;


        }
        [Authorize(Roles = "Admin,Doctor")]
        [HttpDelete("{id}")]
        public async Task DeleteMedicine([FromRoute] Guid id)
        {
            await _medicineService.DeleteById(id);
        }

    }
}
