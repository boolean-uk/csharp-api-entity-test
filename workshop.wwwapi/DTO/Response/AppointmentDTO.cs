using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}
