using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Dtoes.AppointmentDtos
{
    public class AppointmentDto
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int? PrescriptionId { get; set; }

        public AppointmentDto(Appointment appointment)
        {
            Booking = appointment.Booking;
            DoctorId = appointment.DoctorId;
            PatientId = appointment.PatientId;
        }
    }
}
