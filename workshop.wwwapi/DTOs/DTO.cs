using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    class PatientResponseDTO
    {
        public int PatientId {  get; set; }
        public string FullName { get; set; }

        public List<PatientAppointmentDTO> Appointments { get; set; } = new List<PatientAppointmentDTO>();
        
        public PatientResponseDTO(Patient patient) 
        {
            PatientId = patient.Id;
            FullName = patient.FullName;

            foreach(Appointment appointment in patient.Appointments)
            {
                Appointments.Add(new PatientAppointmentDTO(appointment));
            }
        }
    }

    class DoctorResponseDTO
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public List<DoctorAppointmentDTO> Appointments { get; set; } = new List<DoctorAppointmentDTO>();

        public DoctorResponseDTO(Doctor doctor)
        {
            DoctorId = doctor.Id; 
            FullName = doctor.FullName;

            foreach(Appointment appointment in doctor.Appointments)
            {
                Appointments.Add(new DoctorAppointmentDTO(appointment));
            }
        }
    }

    class PatientAppointmentDTO
    {
        public DateTime Booking {  get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }

        public PatientAppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            DoctorId = appointment.DoctorId;
            Doctor = new DoctorDTO(appointment.Doctor);
        }
    }
    class DoctorAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public DoctorAppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            PatientId = appointment.PatientId;
            Patient = new PatientDTO(appointment.Patient);
        }

    }

    class PatientDTO
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }

        public PatientDTO(Patient patient)
        {
            PatientId = patient.Id;
            FullName = patient.FullName;
        }

    }
    class DoctorDTO
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }

        public DoctorDTO(Doctor doctor)
        {
            DoctorId = doctor.Id;
            FullName = doctor.FullName;
        }
    }
    class AppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
        public AppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            PatientId = appointment.PatientId;
            Patient = new PatientDTO(appointment.Patient);
            DoctorId = appointment.DoctorId;
            Doctor = new DoctorDTO(appointment.Doctor);
        }
    }


}
