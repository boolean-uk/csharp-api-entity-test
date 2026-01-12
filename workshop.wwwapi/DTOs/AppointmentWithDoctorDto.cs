namespace workshop.wwwapi.DTOs
{
    // each appointment of a patient should include the doctor's name / id
    public class AppointmentWithDoctorDto
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;

        public DateTime Booking { get; set; }
    }
}