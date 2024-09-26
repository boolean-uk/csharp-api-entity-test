using System.Text.Json.Serialization;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorAppointmentDTO
    {
        public DateTime appointmantDate { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }
        public DoctorPatientDTO patientDTO { get; set; }

        public DoctorAppointmentDTO(Appointment appointment) 
        {
            appointmantDate = appointment.appointmentDate;
            DoctorId = appointment.DoctorId;
            
            PatientId = appointment.PatientId;
            patientDTO = new DoctorPatientDTO(appointment.Patient);
            
        }
        [JsonConstructor]
        public DoctorAppointmentDTO()
        {
            
        }
    }
}
