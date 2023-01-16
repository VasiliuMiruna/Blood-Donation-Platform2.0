using blood_donation_backend.blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blood_donation_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorsController : ControllerBase
    {
        private readonly IDonorService _donorService;

        public DonorsController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DonorModel donor)
        {
            _donorService.Create(donor);
            return Ok(donor);
        }

        [HttpGet]
        public async Task<List<DonorModel>> GetDonor()
        {
            var donors = await _donorService.GetAll();
            return donors;
        }

        [HttpGet("{id}")]
        public async Task<DonorModel> GetDonorById([FromRoute] Guid id)
        {
            var donor = await _donorService.GetById(id);
            return donor;


        }
        [HttpPut("{id}")]
        public async Task UpdateDonor([FromRoute] Guid id, [FromBody] DonorModel donor)
        {
            donor.Id = id;
            await _donorService.UpdateById(id, donor);
        }

        [HttpGet("patients/{id}")]
        public async Task<List<PatientModel>> GetPatientList([FromRoute] Guid id)
        {
            var patients = await _donorService.GetPatientsOfDonors(id);
            return patients;
        }
        [HttpGet("bloodType/{bloodType}")]
        public async Task<List<DonorModel>> FindDonors([FromRoute] string bloodType)
        {
            var donors = await _donorService.GetDonorsByBloodType(bloodType);
            return donors;

        }

        [HttpDelete("{id}")]
        public async Task DeleteDonor([FromRoute] Guid id)
        {
            await _donorService.DeleteDonor(id);
        }

    }
}
