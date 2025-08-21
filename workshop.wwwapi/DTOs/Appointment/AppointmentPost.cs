using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTOs.Appointment
{
    public class AppointmentPost
    {
        public DateTime AppointmentDate { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

    }
}
