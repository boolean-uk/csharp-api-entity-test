using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO.Responses
{
    public class AppointmentPatientDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
}
