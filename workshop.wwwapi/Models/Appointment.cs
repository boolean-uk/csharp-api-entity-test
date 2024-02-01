using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {
        [Column("appointment_id")]
        public int Id {  get; set; }
        [Column("appointment_time")]
        public DateTime Booking { get; set; }

        [ForeignKey("doctor_id")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;

        [ForeignKey("patient_id")]
        [Column("patient_id")]  
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

    }
  
   
}
