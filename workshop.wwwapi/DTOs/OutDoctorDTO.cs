using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class OutDoctorDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public ICollection<OutAppointmentDTO> Appointments { get; set; } = new List<OutAppointmentDTO>();
    }
}
