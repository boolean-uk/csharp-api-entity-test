namespace workshop.wwwapi.DTOs
{
    public class AppointmentCreateDTO
    {
        public DateTime Booking { get; set; }
        public int doctorID { get; set; }
        public int patientID { get; set; }

    }
}
