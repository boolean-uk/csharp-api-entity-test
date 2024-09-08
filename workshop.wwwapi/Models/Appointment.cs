using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }

        
        [Column("doctorId")]
        public int DoctorId { get; set; }

        [ForeignKey("Doctor")]
        public Doctor Doctor { get; set; }


        [ForeignKey("patientId")]
        public int PatientId { get; set; }

        [ForeignKey("Patient")]
        public Patient Patient { get; set; }
    }
}
