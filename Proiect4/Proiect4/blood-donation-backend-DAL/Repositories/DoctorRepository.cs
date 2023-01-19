using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Data;
using blood_donation_backend.Entities;
using System.Linq;

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
            
            return _db.Doctors.ToList(); //scot si eu asyncul poate
            
        }

        public async Task<Doctor> GetById(Guid id)
        {
            return _db.Doctors.FirstOrDefault(d => d.DoctorId == id);  //si asta nu trb sa fie async 

        }
        

        public async Task UpdateDoctor(Doctor doctor)
        {

            //aici ar trb doar sa dea update
            _db.Doctors.Update(doctor);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteDoctor(Doctor doctor)
        {
            _db.Doctors.Remove(doctor);
            await _db.SaveChangesAsync();
           
        }
    }
}
