using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDoctorListDTO
    {
        public int id { get; set; }
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string AppointmentType { get; set; }

        public PatientDTO Patient { get; set; }
    }
}
