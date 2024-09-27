using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public record CreateAppointmentPayload(int DoctorId, int PatientId);
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    {
        //[Column("id")]
        //public int Id { get; set; }
        [Column("booking")]
        public DateTime Booking { get; set; }
        
        [Column("doctor_id")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        
        [Column("patient_id")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
