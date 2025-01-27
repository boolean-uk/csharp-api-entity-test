using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}
