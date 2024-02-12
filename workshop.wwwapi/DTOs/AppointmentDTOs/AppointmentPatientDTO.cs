using workshop.wwwapi.DTOs.PatientDTOs;

namespace workshop.wwwapi.DTOs.AppointmentDTOs
{
    public class AppointmentPatientDTO
    {
        public DateTimeOffset Booking {  get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }
    }
}
