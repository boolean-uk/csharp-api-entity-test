using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTOs.Patient
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<AppointmentsForPatientDTO> Appointments { get; set; }
    }
}
