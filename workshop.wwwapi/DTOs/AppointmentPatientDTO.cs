namespace workshop.wwwapi.DTOs
{
    public class AppointmentPatientDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
}
