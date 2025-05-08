using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTOs
{
    public class OutPatientDTO
    {

        public int Id { get; set; }

        public string FullName { get; set; }

        public ICollection<OutAppointmentDTO> Appointments { get; set; } = new List<OutAppointmentDTO>();
    }
}
