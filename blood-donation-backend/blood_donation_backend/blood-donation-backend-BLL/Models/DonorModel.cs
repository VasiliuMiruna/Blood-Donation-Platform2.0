using blood_donation_backend.blood_donation_backend.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace blood_donation_backend.blood_donation_backend.BLL.Models
{
    public class DonorModel
    {
        public Guid Id { get; set; }
        [StringLength(70)]
        public string? FirstName { get; set; }

        [StringLength(70)]
        public string? LastName { get; set; }

        [Range(0, 100)]
        public int Age { get; set; }
        public string? BloodType { get; set; }

        public string? Gender { get; set; }
        /*public int UserId { get; set; }
        public virtual AppUser User { get; set; }*/

        public ICollection<Guid>? Patients { get; set; }
    }
}
