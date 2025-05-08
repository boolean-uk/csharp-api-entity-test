namespace workshop.wwwapi.Models.DTOs
{
    public class AppointmentForPatientDto
    {
        public GetDoctorDto Doctor { get; set; }
        public DateTime Booking { get; set; }
    }
}
