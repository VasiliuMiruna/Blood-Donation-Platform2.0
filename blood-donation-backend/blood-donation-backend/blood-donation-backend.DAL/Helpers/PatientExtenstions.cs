using blood_donation_backend.Entities;

namespace blood_donation_backend.blood_donation_backend.DAL.Helpers
{
    public static class PatientExtenstions
    {
        public static IQueryable<Patient> WhereClauses(this IQueryable<Patient> patients, Guid id)
        {
            return patients
                
                .Where(x => x.PatientId == id);
        }

    }
}
