namespace workshop.wwwapi.Models.Post.Core
{
    public class AppointmentPost
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public AppointmentType AppointmentType{ get; set; }
        public DateTime Booking { get; set; }
    }
}
