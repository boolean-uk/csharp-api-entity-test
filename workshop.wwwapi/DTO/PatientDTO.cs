using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    
        public PatientDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
        }
    }

    public class PatientResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<AppointmentDTO> Appointments { get; set; }
    
        public PatientResponseDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
            foreach (var appointment in patient.Appointments)
            {
                Appointments.Add(new AppointmentDTO(appointment));
            }
        }
    }

    public class PatientApointmentDTO
    {
        public DoctorDTO Doctor { get; set; }
        public PatientApointmentDTO(Appointment appointment)
        {
            Doctor = new DoctorDTO(appointment.Doctor);
        }
    }
    
}