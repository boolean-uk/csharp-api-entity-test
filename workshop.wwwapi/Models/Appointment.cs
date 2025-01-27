using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Enums;

namespace workshop.wwwapi.Models
{

    public class Appointment
    {
        public DateTime Booking { get; set; } = DateTime.UtcNow;
        public AppointmentType AppointmentType { get; set; } = AppointmentType.AtDoctors;
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public List<Prescription> Prescriptions { get; set; } = [];

    }
}
