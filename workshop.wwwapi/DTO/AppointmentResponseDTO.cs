using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentResponseDTO
    {
        public string Booking { get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO Doctor { get; set; }
        public int PatientId { get; set; }
        public PatientDTO Patient { get; set; }

        public AppointmentResponseDTO(Appointment appointment) 
        {
            Booking = appointment.Booking;
            DoctorId = appointment.DoctorId;
            PatientId = appointment.PatientId;
            Doctor = new DoctorDTO(appointment.Doctor);
            Patient = new PatientDTO(appointment.Patient);
        }

        public static List<AppointmentResponseDTO> FromRepository(IEnumerable<Appointment> appointments)
        {
            var results = new List<AppointmentResponseDTO>();
            foreach (var appointment in appointments)
                results.Add(new AppointmentResponseDTO(appointment));
            return results;
        }

        public static AppointmentResponseDTO FromARepository(Appointment appointment)
        {
            AppointmentResponseDTO result = new AppointmentResponseDTO(appointment);
            return result;
        }

    }
}
