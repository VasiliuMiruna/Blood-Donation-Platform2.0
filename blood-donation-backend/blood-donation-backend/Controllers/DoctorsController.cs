using blood_donation_backend.blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blood_donation_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DoctorModel doctor)
        {
            _doctorService.Create(doctor);
            //await _doctorService.SaveChangesAsync();
            return Ok(doctor);
        }

        [HttpGet]
        public async Task<List<DoctorModel>> GetDoctors()
        {
            var doctors = await _doctorService.GetAll();
            return doctors;
        }

        [HttpGet("byId")]
        public async Task<DoctorModel> GetDoctor([FromQuery] Guid id)
        {
            var doctor = await _doctorService.GetById(id);
            return doctor;


        }
        [HttpPut("updateDoctor")]
        public async Task UpdateDoctor([FromQuery] Guid id, [FromBody] DoctorModel doctor)
        {
            doctor.Id = id;
            await _doctorService.UpdateById(doctor);
        }
    }
}
