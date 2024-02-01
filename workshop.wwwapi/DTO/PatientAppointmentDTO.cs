using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientAppointmentDTO
    {
        public DoctorDTO Doctor {get; set;}
        public DateTime AppointmentTime {get; set;}

        public PatientAppointmentDTO(Appointment appointment)
        {
            AppointmentTime = appointment.Booking;
            Doctor = new DoctorDTO(appointment.Doctor);
        }

    }
}