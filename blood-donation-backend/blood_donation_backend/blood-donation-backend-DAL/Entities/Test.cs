

namespace blood_donation_backend.Entities
{
    public class Test
    {
        public Guid TestId { get; set; }    
        public DateTime? Date { get; set; }

        public string? Type { get; set; }

        public string? Result { get; set; }

        public Guid? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public Guid? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public Guid? DonorId { get; set; }
        public Donor? Donor { get; set; }



    }
}
