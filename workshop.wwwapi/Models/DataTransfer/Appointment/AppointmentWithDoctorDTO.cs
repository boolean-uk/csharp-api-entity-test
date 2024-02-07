using workshop.wwwapi.Models.DataTransfer.Doctor;

namespace workshop.wwwapi.Models.DataTransfer.Appointment
{
    public class AppointmentWithDoctorDTO
    {
        public AppointmentWithDoctorDTO(Domain.Appointment appointment)
        {
            this.AppointmentTime = appointment.AppointmentTime;
            this.Doctor = new DoctorDTO(appointment.Doctor);
        }
        public DateTime AppointmentTime { get; set; }
        public DoctorDTO Doctor { get; set; }
    }
}
