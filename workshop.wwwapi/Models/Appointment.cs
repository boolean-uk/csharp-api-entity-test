using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [PrimaryKey(nameof(PatientId), nameof(DoctorId))]
    [Table("appointments")]
    public class Appointment
    {

        [Required]
        [Column("doctorid")]
        public int DoctorId { get; set; }

        [Required]
        [Column("patientid")]
        public int PatientId { get; set; }

        [Required]
        [Column("booking_time")]
        public DateTime BookingTime { get; set; }

        [Required]
        [Column("type")]
        public AppointmentType Type { get; set; } = AppointmentType.InPerson; //default should be in person

    }
}
