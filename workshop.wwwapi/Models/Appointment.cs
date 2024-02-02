using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [PrimaryKey(nameof(DoctorId), nameof(PatientId))]
    public class Appointment
    {
        [Column("booking")]
        public DateTime Booking { get; set; }

        [ForeignKey("doctor_id")]
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [Column("doctor")]
        public Doctor Doctor { get; set; }

        [ForeignKey("patient_id")]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [Column("patient")]
        public Patient Patient { get; set; }



    }
}
