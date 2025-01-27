using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentPatientListDTO
    {
        public int id { get; set; }
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
        public string AppointmentType { get; set; }

    }
}
