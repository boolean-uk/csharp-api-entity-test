namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTO
    {
        public DateTime Booking { get; set; }

        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }
    }
}
