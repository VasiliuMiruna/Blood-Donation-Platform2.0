using System.ComponentModel.DataAnnotations;

namespace blood_donation_backend.blood_donation_backend.BLL.Models
{
    public class DoctorModel
    {
        public Guid Id { get; set; }

        [StringLength(70)]
        public string? FirstName { get; set; }

        [StringLength(70)]
        public string? LastName { get; set; }

        [Range(0, 100)]
        public int? Age { get; set; }

        public int? Salary { get; set; }
    }
}
