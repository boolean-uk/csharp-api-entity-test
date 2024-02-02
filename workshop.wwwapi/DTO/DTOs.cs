using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    //Patient
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
    class PatientResponseDTO
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }

        public PatientResponseDTO(Patient patient)
        {
            PatientId = patient.Id;
            FullName = patient.FullName;


        }
    }
    
    //PatientAppointment
    class PAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }

        public PAppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            DoctorId = appointment.DoctorId;
            Doctor = new DoctorDTO(appointment.Doctor);
        }
    }

    //Doctor
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
    class DoctorResponseDTO
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }
        public List<DAppointmentDTO> Appointments { get; set; } = new List<DAppointmentDTO>();

        public DoctorResponseDTO(Doctor doctor)
        {
            FullName = doctor.FullName;
            DoctorId = doctor.Id;

            foreach (Appointment appointment in doctor.Appointments)
            {
                Appointments.Add(new DAppointmentDTO(appointment));
            }

            Message = $"The doctor has these appointments:";
        }
    }
    //DoctorAppointment
    class DAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public DAppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            PatientId = appointment.PatientId;
            Patient = new PatientDTO(appointment.Patient);
        }

    }

    //Appointment
    class AppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
        public AppointmentType Type { get; set; }
        public AppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            PatientId = appointment.PatientId;
            Patient = new PatientDTO(appointment.Patient);
            DoctorId = appointment.DoctorId;
            Doctor = new DoctorDTO(appointment.Doctor);
            Type = appointment.Type;
        }
    }
}