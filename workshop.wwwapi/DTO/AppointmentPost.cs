using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentPost
    {
        public int id { get; set; }
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string AppointmentType { get; set; }
    }
}
