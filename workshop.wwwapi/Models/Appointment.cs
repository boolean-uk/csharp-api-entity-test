using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [PrimaryKey(nameof(DoctorId), nameof(PatientId))]
    public class Appointment
    {
        [Required]
        [Column("date", TypeName = "timestamp")]
        public DateTime Booking { get; set; }
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

    }
}
