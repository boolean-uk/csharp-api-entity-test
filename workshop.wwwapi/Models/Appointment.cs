using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("booking")]
        public DateTime Booking { get; set; }
        [Column("doctorid")]
        public int DoctorId { get; set; }
        [Column("patientid")]
        public int PatientId { get; set; }

    }
}
