using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDTOwithName
    {
        public DateTime Booking { get; set; }
        public string DoctorName { get; set; }
        public int DoctorId { get; set; }
        public Prescription Prescription { get; set; }
    }
}
