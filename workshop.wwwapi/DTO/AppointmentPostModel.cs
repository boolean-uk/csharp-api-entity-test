namespace workshop.wwwapi.DTO
{
    public class AppointmentPostModel
    {
        public DateTime Booking {  get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
