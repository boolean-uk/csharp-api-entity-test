using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{

    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    
        public DoctorDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
        }
    }

    public class DoctorResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<AppointmentDTO> Appointments { get; set; }
    
        public DoctorResponseDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
            foreach (var appointment in doctor.Appointments)
            {
                Appointments.Add(new AppointmentDTO(appointment));
            }
        }
    }

    public class DoctorApointmentDTO
    {
        public PatientDTO Patient { get; set; }
        public DoctorApointmentDTO(Appointment appointment)
        {
            Patient = new PatientDTO(appointment.Patient);
        }
    }

}