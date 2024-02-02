using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime Booking {  get; set; }
        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }
    }

    public class AppointmentForDoctorDTO
    {
        public DateTime Booking { get; set; }   
        public int PatientId { get; set; }
    }
}
