using workshop.wwwapi.Models;


namespace workshop.wwwapi.DTO
{
    public class AppointmentResponseDTO
    {
        public int Id { get; set; }
        public PatientDTO Patient { get; set; }
        public DoctorDTO Doctor { get; set; }
        public DateTime AppointmentTime { get; set; }

        public AppointmentResponseDTO(Appointment appointment)
        {
            Id = appointment.Id;
            AppointmentTime = appointment.Booking;
            Patient = new PatientDTO(appointment.Patient);
            Doctor = new DoctorDTO(appointment.Doctor);
        }

        public static List<AppointmentResponseDTO> FromRepository(IEnumerable<Appointment> appointments)
        {
            var results = new List<AppointmentResponseDTO>();
            foreach (Appointment appointment in appointments)
            {
                results.Add(new AppointmentResponseDTO(appointment));
            }
            return results;
        }

        public static AppointmentResponseDTO FromRepository(Appointment appointment)
        {
            return new AppointmentResponseDTO(appointment);
        }
    }
}
