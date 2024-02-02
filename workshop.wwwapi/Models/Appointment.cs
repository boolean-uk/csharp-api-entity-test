using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Enum;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("Appointments")]
    public class Appointment
    {

        [Column("Booking")]
        public DateTime Booking { get; set; }

        [Key]
        [Column("doctor_id")] 
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Key]
        [Column("Patient_id")] 
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Column("Appointment_type")]
        public AppointmentType Type { get; set; }

    }
}
