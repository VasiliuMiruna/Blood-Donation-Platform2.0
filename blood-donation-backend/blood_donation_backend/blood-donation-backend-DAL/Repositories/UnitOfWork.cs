using blood_donation_backend.blood_donation_backend.DAL.Interfaces;
using blood_donation_backend.Data;
using Proiect4.blood_donation_backend_DAL.Interfaces;
using Proiect4.blood_donation_backend_DAL.Repositories;

namespace blood_donation_backend.blood_donation_backend.DAL.Repositories
{
    public class UnitOfWork : IUnitofWork
    {
        protected readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Donors = new DonorRepository(context);
            Patients = new PatientRepository(context);
            Doctors = new DoctorRepository(context);
            Admins = new AdminRepository(context);
            
        }

        public IDonorRepository Donors { get; private set; }
        public IPatientRepository Patients { get; private set; }
        public IDoctorRepository Doctors { get; private set; }

        public IAdminRepository Admins { get; private set; }

       


        /*public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
*/
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    
}
}
