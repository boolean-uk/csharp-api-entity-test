using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace workshop.wwwapi.DTOs
{
    public class GenericDTO
    {
        public string FullName { get; set; }
        public List<GenericAppointmentDTO> Appointments { get; set; }
    }
}
