using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class AppointmentDoctorDTO
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public String PatientName { get; set; }

    }
}
