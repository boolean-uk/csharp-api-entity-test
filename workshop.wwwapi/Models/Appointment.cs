using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table ("appointments")]
    public class Appointment
    {
        [Column ("id")]
        public int Id { get; set; }
        public DateTime Booking { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
