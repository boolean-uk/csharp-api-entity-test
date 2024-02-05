using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public DateTime Booking { get; set; }
    }
}
