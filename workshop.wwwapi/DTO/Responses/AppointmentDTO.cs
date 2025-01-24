using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTO.Responses
{
    public class AppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
