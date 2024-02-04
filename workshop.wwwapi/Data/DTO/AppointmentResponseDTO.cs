using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO
{
    public class AppointmentResponseDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime Booking { get; set; }
        public string AppointmentType { get; set; }
    }
}
