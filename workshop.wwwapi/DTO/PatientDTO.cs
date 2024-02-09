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

    public class PatientAppointmentDTO
    {
        public DateTime Booking { get; set; }

        public string Type { get; set; }
        public DoctorDTO Doctor { get; set; }

        public PrescriptionDTO Prescription { get; set; }
        public PatientAppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            Type = appointment.Type;
            Doctor = new DoctorDTO(appointment.Doctor);
            Prescription = new PrescriptionDTO(appointment.Prescription);
        }
    }
}