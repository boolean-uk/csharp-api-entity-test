using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorDTO
    {
        public string FullName { get; set; }
        public List<AppointmentDTO> Appointments { get; set; }
    }
}