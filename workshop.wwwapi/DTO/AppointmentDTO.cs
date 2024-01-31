using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDTO
    {
        public string Booking { get; set; }

        public int DoctorId { get; set; }

        public DoctorDTO Doctor { get; set; }

        public int PatientId { get; set; }

        public AppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            DoctorId = appointment.DoctorId;
            Doctor = new DoctorDTO(appointment.Doctor);
            PatientId = appointment.PatientId;
        }
    }
}
