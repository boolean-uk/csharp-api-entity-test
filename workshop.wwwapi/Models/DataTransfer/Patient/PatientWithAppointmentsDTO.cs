using workshop.wwwapi.Models.DataTransfer.Appointment;

namespace workshop.wwwapi.Models.DataTransfer.Patient
{
    public class PatientWithAppointmentsDTO
    {
        public PatientWithAppointmentsDTO(Domain.Patient patient)
        {
            this.FullName = patient.FullName;
            foreach (var appointment in patient.Appointments)
            {
                this.Appointments.Add(new AppointmentWithDoctorDTO(appointment));
            }
        }
        public string FullName { get; set; }
        public List<AppointmentWithDoctorDTO> Appointments { get; set; } = new List<AppointmentWithDoctorDTO>();
    }
}
