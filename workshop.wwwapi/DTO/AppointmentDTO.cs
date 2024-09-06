using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDTO
    {
        public DateTime Booking { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public string PatientName { get; set;}
        public string DoctorName { get; set;}

        public string Type { get; set; }

    }
}
