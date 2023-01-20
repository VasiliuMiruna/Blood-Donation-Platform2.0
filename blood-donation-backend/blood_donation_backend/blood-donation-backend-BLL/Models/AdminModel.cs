using System.ComponentModel.DataAnnotations;

namespace Proiect4.blood_donation_backend_BLL.Models
{
    public class AdminModel
    {
        public Guid Id { get; set; }

        [StringLength(70)]
        public string? FirstName { get; set; }

        [StringLength(70)]
        public string? LastName { get; set; }

 
    }
}
