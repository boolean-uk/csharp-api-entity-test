using workshop.wwwapi.Models.DatabaseModels;

namespace workshop.wwwapi.Models
{
    public class DoctorAppointmentDto
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string AppointmentType { get; set; }
    }
}
