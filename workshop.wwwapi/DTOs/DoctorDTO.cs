using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public IEnumerable<AppointmentDTO> Appointments { get; set; } = [];
    }
}
