using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("appointments")]
    public class Appointment
    { 
        public DateTime Booking { get; set; }

        [ForeignKey("doctors")]
        public int DoctorId { get; set; }

        [ForeignKey("patients")]
        public int PatientId { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

    }
}
