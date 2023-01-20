using blood_donation_backend.blood_donation_backend.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace blood_donation_backend.Entities
{
    public class Doctor
    {
        public Guid DoctorId { get; set; }

        [StringLength(70)]
        public string? FirstName { get; set; }

        [StringLength(70)]
        public string? LastName { get; set; }

        [Range(0, 100)]
        public int? Age { get; set; }

        public int? Salary { get; set; }

        public ICollection<Test>? Tests { get; set; }

        public IList<PatientDoctor>? PatientDoctors { get; set; }
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }

    }
}
