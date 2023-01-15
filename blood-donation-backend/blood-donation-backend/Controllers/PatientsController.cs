using blood_donation_backend.BLL.Interfaces;
using blood_donation_backend.blood_donation_backend.BLL.Models;
using blood_donation_backend.Data;
using blood_donation_backend.Entities;
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
            _patientService.Create(patient);
            //await _patientService.SaveChangesAsync();
            return Ok(patient);
        }

        [HttpGet]
        public async Task<List<PatientModel>> GetPatients()
        {
            var patients = await _patientService.GetAll();
            return patients;
        }

        [HttpGet("byId")]
        public async Task<PatientModel> GetPatient([FromQuery]Guid id)
        {
            var patient = await _patientService.GetById(id);
            return patient;


        }
        [HttpPut("updatePatient")]
        public async Task UpdatePatient([FromQuery]Guid id, [FromBody]PatientModel patient)
        {
            patient.Id = id;
            await _patientService.UpdateById(patient);
        }

        [HttpDelete("deletePatientById")]
        public async Task DeletePatient([FromQuery]Guid id)
        {
            await _patientService.DeleteById(id);
        }

        [HttpGet("getMedicines")]
        public async Task<List<MedicineModel>> GetMedicines([FromQuery] Guid id)
        {
            var medicineList =await _patientService.GetMedicinesByPatientId(id);
            return medicineList;
        }

       
       

        /*   public static List<Patient> patients = new List<Patient>
           {
               new Patient { FirstName = "Alex", LastName = "Brinza", Age = 19, BloodType = "O-" },
               new Patient { FirstName = "Florin", LastName = "Mihalcea", Age = 25, BloodType = "A+" },
               new Patient { FirstName = "Emanuel", LastName = "Radu", Age = 24, BloodType = "AB+" },
               new Patient { FirstName = "Emanuel", LastName = "Radu", Age = 24, BloodType = "AB+" },
               new Patient { FirstName = "Emanuel", LastName = "Andrei", Age = 24, BloodType = "AB+" }

           };

   */

        /*  [HttpGet]
          public List<Patient> Get()
          {
              return patients;
          }*/
        /*
                [HttpGet("byId")]
                public Patient GetById(int id)
                {
                    return patients.FirstOrDefault(x => x.Id == id);
                }

                [HttpGet("byId/{Id}")]

                public Patient GetByIdInEndpoint(int id)
                {
                    return patients.FirstOrDefault(s => s.Id.Equals(id));
                }

                [HttpGet("filter/{firstName}/{age}")]

                public List<Patient> GetWithFilters(string firstName, int age)
                {
                    return patients.Where(p=>p.FirstName.ToLower().Equals(firstName.ToLower()) && p.Age == age).ToList();
                }*/

        /*     [HttpGet("fromRouteWithId/{id}")]

             public Patient GetFromRouteWithId([FromRoute] int id)
             {
                 Patient patient = patients.FirstOrDefault(p => p.Id.Equals(id));
                 return patient;
             }
     */

        //Create
        /*  [HttpPost]
          public IActionResult AddPatient(Patient patient)
          {
              if(patient != null)
                  patients.Add(patient);
              return Ok();
          }
  */


    }
}
