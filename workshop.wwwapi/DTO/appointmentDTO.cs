using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class appointmentDTO
    {
       
        public DateTime appointmentDate { get; set; }
       
        public int DoctorId { get; set; }

        public AppointmentDoctorDTO Doctor { get; set; }

        
        public int PatientId { get; set; }

        public AppointmentPatientDTO Patient { get; set; }

        public appointmentDTO(Appointment appointment) 
        {
            appointmentDate = appointment.appointmentDate;
            DoctorId = appointment.DoctorId;
            PatientId = appointment.PatientId;

            Doctor = new AppointmentDoctorDTO(appointment.Doctor);
            Patient = new AppointmentPatientDTO(appointment.Patient);
        }
        [JsonConstructor]
        public appointmentDTO()
        {
            
        }

    }
}
