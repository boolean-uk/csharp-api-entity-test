using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<DoctorAppointmentDTO> Appointments { get; set; }
    }

    public class CreatePatientDTO
    {
        [Required]
        public string FullName { get; set; }
    }
}
