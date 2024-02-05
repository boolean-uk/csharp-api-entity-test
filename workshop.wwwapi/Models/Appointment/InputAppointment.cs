namespace workshop.wwwapi.Models
{
    public class InputAppointment
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime Booking { get; set; }
    }
}
