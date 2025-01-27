namespace workshop.wwwapi.DTOs
{
    public class AppointmentWithPatient
    {
        public DateTime Booking { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
    }
}
