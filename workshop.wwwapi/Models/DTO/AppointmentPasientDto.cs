using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DTO
{
    public class AppointmentPasientDto
    {
        public DateTime Booking { get; set; }

        public int DoctorId { get; set; }
        public string Name { get; set; }
    }
}
