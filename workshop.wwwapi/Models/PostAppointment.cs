namespace workshop.wwwapi.Models
{
    public class PostAppointment
    {
        public DateTime AppointmentTime { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
