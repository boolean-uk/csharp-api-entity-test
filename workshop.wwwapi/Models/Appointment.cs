using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class Appointment
    {
        [Column("id")]
        public int Id { get; set; } 
        
        [Column("booking", TypeName = "timestamp with time zone")]
        public DateTime Booking { get; set; }

        [Column("doctor_id_fk", TypeName = "int")]
        public int DoctorId { get; set; }
        
        [Column("doctor")]
        public Doctor Doctor { get; set; }

        [Column("patient_id_fk", TypeName = "int")]
        public int PatientId { get; set; }
        
        [Column("patient")]
        public Patient Patient { get; set; }
    }
}