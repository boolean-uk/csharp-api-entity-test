namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTOwithName
    {
        public DateTime Booking { get; set; }
        public string DoctorName { get; set; }
        public int DoctorId { get; set; }
        public string PatientName { get; set; }
        public int PatientId { get; set; }
    }
}
