using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly

    [Table("appointments")]
    public class Appointment
    {

        [Column("booking")]
        public DateTime Booking { get; set; }

        [ForeignKey("doctorId")]
        [Column("doctorId")]
        public int DoctorId { get; set; }

        [ForeignKey("patientId")]
        [Column("patientId")]
        public int PatientId { get; set; }

    }
}
