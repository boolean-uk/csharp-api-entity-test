using workshop.wwwapi.Models.DataTransfer.Doctor;
using workshop.wwwapi.Models.DataTransfer.Patient;

namespace workshop.wwwapi.Models.DataTransfer.Appointment
{
    public class AppointmentWithDoctorAndPatientDTO
    {
        public AppointmentWithDoctorAndPatientDTO(Domain.Appointment appointment)
        {
            this.AppointmentTime = appointment.AppointmentTime;
            this.Doctor = new DoctorDTO(appointment.Doctor);
            this.Patient = new PatientDTO(appointment.Patient);
        }
        public DateTime AppointmentTime { get; set; }
        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }
    }
}
