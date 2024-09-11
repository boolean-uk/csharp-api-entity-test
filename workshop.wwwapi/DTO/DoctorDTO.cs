using workshop.wwwapi.Models;

namespace wwwapi.DTO
{
    public class DoctorReturnDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<AppointmentForDoctorDTO> Appointments { get; set; } = new List<AppointmentForDoctorDTO>();

        public DoctorReturnDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
            foreach (Appointment a in doctor.Appointments)
            {
                Appointments.Add(new AppointmentForDoctorDTO(a));
            }
        }

        public static List<DoctorReturnDTO> ListOfDoctors(List<Doctor> doctors)
        {
            List<DoctorReturnDTO> doctorReturnDTOs = new List<DoctorReturnDTO>();
            foreach (Doctor doctor in doctors)
            {
                doctorReturnDTOs.Add(new DoctorReturnDTO(doctor));
            }
            return doctorReturnDTOs;
        }
    }

    public class AppointmentForDoctorDTO
    {
        public DateTime Booking { get; set; }
        public PatientForAppointmentDTO Patient { get; set; }

        public AppointmentForDoctorDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            Patient = new PatientForAppointmentDTO(appointment.Patient);
        }
    }

    public class PatientForAppointmentDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public PatientForAppointmentDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
        }
    }
}