using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly

    [Table("appointments")]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }

        [Column("doctorid")]
        public int DoctorId { get; set; }

        [Column("patientid")]
        public int PatientId { get; set; }

        public List<Appointment> Appointments { get; set; }

    }
}
