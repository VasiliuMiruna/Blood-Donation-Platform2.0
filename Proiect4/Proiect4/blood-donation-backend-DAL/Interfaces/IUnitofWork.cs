using Proiect4.blood_donation_backend_DAL.Interfaces;

namespace blood_donation_backend.blood_donation_backend.DAL.Interfaces
{
    public interface IUnitofWork 
    {
        IDonorRepository Donors { get; }
        IPatientRepository Patients { get; }
        
        IDoctorRepository Doctors { get; }
        IAdminRepository Admins { get; }

        /*void Complete();*/

        Task<int> SaveChangesAsync();
    }
}
