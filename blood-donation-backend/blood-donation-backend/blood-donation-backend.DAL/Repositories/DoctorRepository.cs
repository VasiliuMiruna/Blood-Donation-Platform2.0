using blood_donation_backend.blood_donation_backend.DAL.Helpers;
using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Data;
using blood_donation_backend.Entities;

namespace blood_donation_backend.blood_donation_backend.DAL.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _db;

        public DoctorRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task Create(Doctor doctor)
        {
            await _db.Doctors.AddAsync(doctor);
            await _db.SaveChangesAsync();
        }



        public async Task<List<Doctor>> GetAll()
        {
            var doctors = _db.Doctors;
            var list = new List<Doctor>();
            foreach (var doctor in doctors)
            {
                var doctorModel = new Doctor
                {
                    DoctorId = doctor.DoctorId,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Age = doctor.Age,
                    Salary = doctor.Salary
                };
                list.Add(doctorModel);
            }
            return list;
        }

        public async Task<Doctor> GetById(Guid id)
        {

            var doctors = _db.Doctors.WhereClauses(id);
            var doctordb = new Doctor();
            foreach (var doctor in doctors)
            {
                doctordb.DoctorId = doctor.DoctorId;
                doctordb.FirstName = doctor.FirstName;
                doctordb.LastName = doctor.LastName;

                doctordb.Age = doctor.Age;
                doctordb.Salary = doctor.Salary;
            }
            return doctordb;
        }
        /*   public void Delete(Patient patient)
           {
               db.Patients.Remove(patient);
               db.SaveChanges();
           }

           public void Update(Patient patient)
           {
               db.Patients.Update(patient);
               db.SaveChanges();
           }*/

        public async Task UpdateDoctor(Doctor doctor)
        {
     

            var newDoctor = _db.Doctors.Find(doctor.DoctorId);
            if (newDoctor != null)
            {
                newDoctor.FirstName = doctor.FirstName;
                newDoctor.LastName = doctor.LastName;
                newDoctor.Age = doctor.Age;
                newDoctor.Salary = doctor.Salary;
                _db.SaveChangesAsync();
            }
        }
    }
}
