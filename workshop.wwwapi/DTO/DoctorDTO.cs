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

    public class DoctorAppointmentDTO
    {
        public DateTime Booking { get; set; }

        public string Type { get; set; }
        public PatientDTO Patient { get; set; }

        public PrescriptionDTO Prescription { get; set; }
        public DoctorAppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            Type = appointment.Type;
            Patient = new PatientDTO(appointment.Patient);
            Prescription = new PrescriptionDTO(appointment.Prescription);
        }
    }

}