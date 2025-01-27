namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTONoIDWithName
    {
        public DateTime Booking { get; set; }
        public string DoctorName { get; set; }

        public string PatientName { get; set; }
    }
}
