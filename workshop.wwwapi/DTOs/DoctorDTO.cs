using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class DoctorDTO
    {
        public string Name { get; set; }
        public List<AppointmentForDoctorDTO> Appointments { get; set; } = new List<AppointmentForDoctorDTO>();
    }
}
