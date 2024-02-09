using System.Text.Json.Serialization;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientAppointmentDTO
    {
        public DateTime Booking {  get; set; }

        public int DoctorId { get; set; }
        public PatientDoctorDTO Doctor { get; set; }

        public int PatientId { get; set; }

        public PatientAppointmentDTO(Appointment appointment) 
        {
            Booking = appointment.appointmentDate;
            DoctorId = appointment.DoctorId;
            Doctor = new PatientDoctorDTO(appointment.Doctor);
            PatientId = appointment.PatientId;
            
        }
        [JsonConstructor]
        public PatientAppointmentDTO() { }

    }
}
