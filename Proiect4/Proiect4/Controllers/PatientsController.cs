using blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Models;
using blood_donation_backend.Data;
using blood_donation_backend.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blood_donation_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientModel patient)
        {
            await _patientService.Create(patient);
            return Ok(patient);
        }

        [Authorize(Roles="Admin,Doctor")]
        [HttpGet]
        public async Task<List<PatientModel>> GetPatients()
        {
            var patients = await _patientService.GetAll();
            return patients;
        }

        [Authorize(Roles = "Admin,Doctor, Patient")]
        [HttpGet("{id}")]
        public async Task<PatientModel> GetPatient([FromRoute]Guid id)
        {
            var patient = await _patientService.GetById(id);
            return patient;


        }

        [Authorize(Roles = "Admin,Doctor,Patient")]
        [HttpPut("{id}")]
        public async Task UpdatePatient([FromRoute]Guid id, [FromBody]PatientModel patient)
        {
            patient.Id = id;
            await _patientService.UpdateById(id, patient);
        }

        [Authorize(Roles = "Admin,Doctor")]
        [HttpDelete("{id}")]
        public async Task DeletePatient([FromRoute]Guid id)
        {
            await _patientService.DeleteById(id);
        }

        [Authorize(Roles = "Admin,Doctor")]
        [HttpGet("medicines/{id}")]
        public async Task<List<MedicineModel>> GetMedicines([FromRoute] Guid id)
        {
            var medicineList =await _patientService.GetMedicinesByPatientId(id);
            return medicineList;
        }



    }
}
