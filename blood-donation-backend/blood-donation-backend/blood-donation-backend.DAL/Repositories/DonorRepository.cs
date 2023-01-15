using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Data;
using blood_donation_backend.Entities;

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
            var donors = _db.Donors;
            var list = new List<Donor>();
            foreach (var donor in donors)
            {
                var donorModel = new Donor
                {
                    DonorId = donor.DonorId,
                    FirstName = donor.FirstName,
                    LastName = donor.LastName,
                    Age = donor.Age,
                    Gender = donor.Gender,
                    BloodType = donor.BloodType
                    
                };
                list.Add(donorModel);
            }
            return list;
        }

        public async Task<Donor> GetById(Guid id)
        {

            /* var donors = _db.Donors.WhereClauses(id);
             var donordb = new Donor();
             foreach (var donor in donors)
             {
                 donordb.DonorId = donor.donorId;
                 donordb.FirstName = donor.FirstName;
                 donordb.LastName = donor.LastName;

                 donordb.Age = donor.Age;

             }
             return donordb;*/
            var donor = _db.Donors.FirstOrDefault(d => d.DonorId == id);
            return donor;
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

        public async Task UpdateDonor(Donor donor)
        {


            var newDonor = _db.Donors.Find(donor.DonorId);
            if (newDonor != null)
            {
                newDonor.FirstName = donor.FirstName;
                newDonor.LastName = donor.LastName;
                newDonor.Age = donor.Age;
                newDonor.Gender = donor.Gender;
                newDonor.BloodType = donor.BloodType;
                
                await _db.SaveChangesAsync();
            }
        }
    }
}
