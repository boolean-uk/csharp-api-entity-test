using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class AppointmentPatientDTO
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public String DoctorName { get; set; }
    }
}
