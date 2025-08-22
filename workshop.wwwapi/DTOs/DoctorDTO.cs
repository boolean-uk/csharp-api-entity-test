using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTOs
{
    public class DoctorDTO
    {
        public string FullName { get; set; }
        public List<AppointmentDTO> Appointments { get; set; } = new();

    }
}
