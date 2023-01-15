using blood_donation_backend.Entities;

namespace blood_donation_backend.blood_donation_backend.DAL.Helpers
{
    public static class DoctorsExtension
    {
        public static IQueryable<Doctor> WhereClauses(this IQueryable<Doctor> doctors, Guid id)
        {
            return doctors

                .Where(x => x.DoctorId == id);
        }

    }
}
