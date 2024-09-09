using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("APPOINTMENT")]
    public class Appointment //composite key of booking and doctor
    {
        
        [Column("APPOINTMENT_DATE")]
        public DateTime Booking { get; set; }

        //public int AppointmentId { get; set; }

        [ForeignKey("DOCTOR")]
        [Column("DOCTOR_ID")]
        public int DoctorId { get; set; }

        public Doctor doctor { get; set; }
        
        [ForeignKey("PATIENT")]
        [Column("PATIENT_ID")]
        public int PatientId { get; set; }

        public Patient patient { get; set; }

    }
}
