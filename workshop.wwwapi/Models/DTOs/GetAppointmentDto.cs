namespace workshop.wwwapi.Models.DTOs
{
    public class GetAppointmentDto
    {
        public GetPatientDto Patient { get; set; }
        public GetDoctorDto Doctor { get; set; }
        public DateTime Booking { get; set; }
    }
}
