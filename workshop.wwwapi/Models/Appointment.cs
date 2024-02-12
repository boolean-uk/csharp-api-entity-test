using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class Appointment
    {
        [Column("booking_time")]
        public DateTime Booking { get; set; }

        [Key, Column("fk_doctor_id")]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [Key, Column("fk_patient_id")]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

    }
}
