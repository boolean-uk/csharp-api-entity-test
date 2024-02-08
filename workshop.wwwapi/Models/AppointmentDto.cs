namespace workshop.wwwapi.Models
{
    public class AppointmentDto
    {
        public DateTime Booking { get; set; }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
    }
}
