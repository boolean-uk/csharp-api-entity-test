using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [Column("appointmentid")]
        public int Id { get; set; }

        [Column("booking")]
        public DateTime Booking { get; set; }

        [Column("doctorid")]
        public int DoctorId { get; set; }

        [Column("patientid")]
        public int PatientId { get; set; }

        [Column("type")]
        public AppointmentType Type { get; set; }

        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }

    }
}
