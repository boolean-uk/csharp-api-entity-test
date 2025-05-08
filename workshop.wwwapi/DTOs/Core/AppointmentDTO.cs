using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs.Core
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO_L1 Doctor { get; set; }
        public int PatientId { get; set; }
        public PatientDTO_L1 Patient { get; set; }
        public string AppointmentType { get; set; }
        public DateTime Booking { get; set; }
    }
}
