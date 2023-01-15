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
            //await _patientService.SaveChangesAsync();
            return Ok(donor);
        }

        [HttpGet]
        public async Task<List<DonorModel>> GetDonor()
        {
            var donors = await _donorService.GetAll();
            return donors;
        }

        [HttpGet("byId")]
        public async Task<DonorModel> GetPatient([FromQuery] Guid id)
        {
            var donor = await _donorService.GetById(id);
            return donor;


        }
        [HttpPut("updateDonor")]
        public async Task UpdatePatient([FromQuery] Guid id, [FromBody] DonorModel donor)
        {
            donor.Id = id;
            await _donorService.UpdateById(donor);
        }

        
    }
}
