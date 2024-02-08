using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO.Server
{
    public class anAppointment
    {
        public DateTime Booking { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }       
    }
}
