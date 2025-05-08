using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly

    [Table("Appointments")]
    public class Appointment
    {
        [Column("booking")]

        public DateTime Booking { get; set; }
        [Column("doctorid")]

        [ForeignKey("doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        [Column("patientid")]

        [ForeignKey("patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }

    }
}
