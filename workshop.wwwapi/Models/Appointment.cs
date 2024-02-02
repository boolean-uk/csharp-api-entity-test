using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [PrimaryKey(nameof(PatientId), nameof(DoctorId))]
    [Table("appointments")]
    public class Appointment
    {

        [Column("doctorid")]
        public int DoctorId { get; set; }

        [Column("patientid")]
        public int PatientId { get; set; }

        [Column("booking_time")]
        public DateTime BookingTime { get; set; }

    }
}
