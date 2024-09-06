using workshop.wwwapi.Models.DatabaseModels;

namespace workshop.wwwapi.Models
{
    public class PatientAppointmentDto
    {
        public DateTime Booking { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string AppointmentType { get; set; }
    }
}
