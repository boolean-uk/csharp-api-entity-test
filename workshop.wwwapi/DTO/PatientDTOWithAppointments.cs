using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientDTOWithAppointments
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<PatientAppointmentDTO> Appointments { get; set; } = new List<PatientAppointmentDTO>();
    }
}
