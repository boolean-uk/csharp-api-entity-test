using workshop.wwwapi.Models.DataTransfer.Patient;

namespace workshop.wwwapi.Models.DataTransfer.Appointment
{
    public class AppointmentWithPatientDTO
    {
        public AppointmentWithPatientDTO(Domain.Appointment appointment)
        {
            this.AppointmentTime = appointment.AppointmentTime;
            this.Patient = new PatientDTO(appointment.Patient);
        }
        public DateTime AppointmentTime { get; set; }
        public PatientDTO Patient { get; set; }
    }
}
