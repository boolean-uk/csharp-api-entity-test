using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }

        [ForeignKey("DoctorId")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [ForeignKey("PatientId")]
        [Column("patient_id")]
        public int PatientId { get; set; }
    }
}
