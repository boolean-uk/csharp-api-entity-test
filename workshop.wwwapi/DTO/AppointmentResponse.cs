using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentResponse
    {
        public List<AppointmentDTO> appointments { get; set; } = new List<AppointmentDTO>();

    }
}
