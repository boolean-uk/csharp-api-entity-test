using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }
        [ForeignKey("doctorid")]
        public int DoctorId { get; set; }
        [ForeignKey("patientid")]
        public int PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
