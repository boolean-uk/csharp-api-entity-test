using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DTOAppointment
    {
        public DateTime Booking { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}
