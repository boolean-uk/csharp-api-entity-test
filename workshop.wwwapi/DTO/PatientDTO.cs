using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public IEnumerable<AppointmentDTO> Appointments { get; set; }

    }
}
