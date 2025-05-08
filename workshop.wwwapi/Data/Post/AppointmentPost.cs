using workshop.wwwapi.Data.Enums;

namespace workshop.wwwapi.Data.Post
{
    public class AppointmentPost
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime BookingTime { get; set; }
        public AppointmentType AppointmentType { get; set; }
    }
}
