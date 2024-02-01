using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{

    public class AppointmentDTO
    {
        public DateTime Booking { get; set; }
        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }
        public AppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            Doctor = new DoctorDTO(appointment.Doctor);
            Patient = new PatientDTO(appointment.Patient);
        }
    }
       
}