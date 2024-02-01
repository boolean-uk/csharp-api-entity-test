using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PAppointmentDTO
    {
        public DateTime Booking {  get; set; }

        public int DoctorId { get; set; }
        public PDoctorDTO Doctor { get; set; }

        public int PatientId { get; set; }

        public PAppointmentDTO(Appointment appointment) 
        {
            Booking = appointment.Booking;
            DoctorId = appointment.DoctorId;
            Doctor = new PDoctorDTO(appointment.Doctor);
            PatientId = appointment.PatientId;
            
        }
    }
}
