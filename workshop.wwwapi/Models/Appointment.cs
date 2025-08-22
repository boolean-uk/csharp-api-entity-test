using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; } = DateTime.UtcNow;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
