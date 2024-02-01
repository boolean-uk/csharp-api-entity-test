using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointment")]
    public class Appointment
    {
        [Column("id")]
        public int Id {get; set;}
        [Column("booking_date")]
        public DateTime Booking { get; set; }
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor {get; set;} = null!;

        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient {get; set;} = null!;
    }
}
