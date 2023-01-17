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
        public ActionResult GetDoctors()
        {
            var doctors =  _doctorService.GetAll();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor([FromRoute] Guid id)
        {
            var doctor = await _doctorService.GetById(id);
            return Ok(doctor);


        }
        [HttpPut("{id}")]
        public ActionResult UpdateDoctor([FromRoute] Guid id, [FromBody] DoctorModel doctor)
        {
            doctor.Id = id;
            _doctorService.UpdateById(id, doctor);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor([FromRoute] Guid id)
        {
            _doctorService.DeleteDoctor(id);
            return Ok();
        }

    }
}
