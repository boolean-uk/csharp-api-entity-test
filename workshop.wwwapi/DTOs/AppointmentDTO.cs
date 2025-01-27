using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTO
    {
        public DateTime Booking { get; set; }

        public int DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; }

    }
}
