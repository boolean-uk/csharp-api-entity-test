namespace workshop.wwwapi.ViewModels
{
    public class AppointmentPostModel
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
