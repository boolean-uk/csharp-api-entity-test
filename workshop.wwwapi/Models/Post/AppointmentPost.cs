namespace workshop.wwwapi.Models.Post
{
    public class AppointmentPost
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime BookingTime { get; set; }
    }
}
