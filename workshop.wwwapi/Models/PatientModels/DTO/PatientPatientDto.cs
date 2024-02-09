using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.PatientModels.DTO
{
    public class PatientPatientDto
    {
        public int PatientId { get; set; }

        public string Name { get; set; }

        public ICollection<AppointmentPatientDto> Appointments { get; set; }
    }
}
