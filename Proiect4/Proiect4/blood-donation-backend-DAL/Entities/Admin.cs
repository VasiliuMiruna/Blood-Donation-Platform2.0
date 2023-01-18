using System.ComponentModel.DataAnnotations;

namespace blood_donation_backend.blood_donation_backend.DAL.Entities
{
    public class Admin
    {

        public Guid AdminId { get; set; }
        [StringLength(70)]
        public string? FirstName { get; set; }

        [StringLength(70)]
        public string? LastName { get; set; }
        public virtual string UserId { get; set; }
        public virtual AppUser User { get; set; }

    }
}
