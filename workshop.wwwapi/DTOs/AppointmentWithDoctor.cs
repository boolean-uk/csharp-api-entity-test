using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class AppointmentWithDoctor
    {
        public DateTime Booking { get; set; }
        public string DoctorName { get; set; }
        public int DoctorId { get; set; }


    }
}
