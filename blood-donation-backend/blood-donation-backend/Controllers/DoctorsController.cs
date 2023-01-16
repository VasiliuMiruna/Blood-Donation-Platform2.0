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
            return Ok(doctor);
        }

        [HttpGet]
        public async Task<List<DoctorModel>> GetDoctors()
        {
            var doctors = await _doctorService.GetAll();
            return doctors;
        }

        [HttpGet("{id}")]
        public async Task<DoctorModel> GetDoctor([FromRoute] Guid id)
        {
            var doctor = await _doctorService.GetById(id);
            return doctor;


        }
        [HttpPut("{id}")]
        public async Task UpdateDoctor([FromRoute] Guid id, [FromBody] DoctorModel doctor)
        {
            doctor.Id = id;
            await _doctorService.UpdateById(id, doctor);
        }

        [HttpDelete("{id}")]
        public async Task DeleteDoctor([FromRoute] Guid id)
        {
            await _doctorService.DeleteDoctor(id);
        }

    }
}
