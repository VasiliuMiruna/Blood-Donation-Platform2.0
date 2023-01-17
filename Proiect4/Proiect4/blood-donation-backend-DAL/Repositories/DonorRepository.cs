using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Data;
using blood_donation_backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace blood_donation_backend.blood_donation_backend.DAL.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly AppDbContext _db;

        public DonorRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task Create(Donor donor)
        {
            await _db.Donors.AddAsync(donor);
            await _db.SaveChangesAsync();
        }



        public async Task<List<Donor>> GetAll()
        {
            return _db.Donors.ToList();
            
        }

        public async Task<Donor> GetById(Guid id)
        {
            var donor = _db.Donors.FirstOrDefault(d => d.DonorId == id);
            return donor;
        }
      

      public async Task UpdateDonor(Donor donor)
        {

            //aici ar trb doar sa dea update
            _db.Donors.Update(donor);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteDonor(Donor donor)
        {
            _db.Donors.Remove(donor);
            await _db.SaveChangesAsync();

        }

        public async Task<List<Patient>> GetPatientsOfDonors(Guid donorId)
        {
            var patientElements = await _db.Patients
                    .Join(_db.Donors, patient => patient.CurrentDonorId, donor => donor.DonorId,
                        (patient, donor) => new { patient, donor })
                    .Where(pd => pd.donor.DonorId == donorId)
                    .Select(pd => pd.patient)
                    .ToListAsync();
            return patientElements;
        }

        public async Task<List<Donor>> GetDonorsByBloodType(string bloodType)
        {
            var donors = await _db.Donors
                .Where(d => d.BloodType == bloodType)
                .ToListAsync();
            return donors;
        }
    }
}
