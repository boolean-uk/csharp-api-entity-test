using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {

        [Column("appointment_Id")]
        public int Id  { get; set; }
        [Column("booking_time")]
        public DateTime Booking { get; set; }
        [Column("doctor_Id")]

        public Doctor doctor { get; set; }
        public int DoctorId { get; set; }
        [Column("patient_Id")]

        public Patient patient { get; set; }
        public int PatientId { get; set; }

    }
}
