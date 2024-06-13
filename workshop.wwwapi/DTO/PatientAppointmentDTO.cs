using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientAppointmentDTO
    {
        public DoctorDTO Doctor { get; set; }
        public DateTime Booking {  get; set; }
        public PatientAppointmentDTO(Appointment appointment) 
        {
            Doctor = new DoctorDTO(appointment.Doctor);
            Booking = appointment.Booking;
        }
    }
}
