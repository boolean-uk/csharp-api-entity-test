using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<PatientAppointmentDTO> Appointments { get; set; }
    }

    public class CreateDoctorDTO
    {
        [Required]
        public string FullName { get; set; }
    }
}
