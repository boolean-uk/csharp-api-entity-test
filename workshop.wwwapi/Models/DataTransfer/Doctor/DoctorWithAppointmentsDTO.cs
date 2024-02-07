using workshop.wwwapi.Models.DataTransfer.Appointment;
using workshop.wwwapi.Models.DataTransfer.Patient;

namespace workshop.wwwapi.Models.DataTransfer.Doctor
{
    public class DoctorWithAppointmentsDTO
    {
        public DoctorWithAppointmentsDTO(Domain.Doctor doctor)
        {
            this.FullName = doctor.FullName;
            foreach (var appointment in doctor.Appointments)
            {
                this.Appointments.Add(new AppointmentWithPatientDTO(appointment));
            }
        }
        public string FullName { get; set; }
        public List<AppointmentWithPatientDTO> Appointments { get; set; } = new List<AppointmentWithPatientDTO>();
    }
}
