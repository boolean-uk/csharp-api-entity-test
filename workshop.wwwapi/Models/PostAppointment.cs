using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    public class PostAppointment
    {
        [Required]
        public DateTime AppointmentTime { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int PatientId { get; set; }
    }
}
