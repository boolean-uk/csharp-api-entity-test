namespace workshop.wwwapi.Models.DTOs
{
    public class AppointmentForDoctorDto
    {
        public GetPatientDto Patient { get; set; }
        public DateTime Booking { get; set; }
    }
}
