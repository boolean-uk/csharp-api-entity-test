using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorAppointmentDTO
    {
        public PatientDTO Patient { get; set; }
        public DateTime AppointmentTime { get; set; }
        public AppointmentType AppointmentType { get; set; }

        public DoctorAppointmentDTO(Appointment appointment)
        {
            AppointmentTime = appointment.Booking;
            Patient = new PatientDTO(appointment.Patient);
            AppointmentType = appointment.Type;

        }

    }
}