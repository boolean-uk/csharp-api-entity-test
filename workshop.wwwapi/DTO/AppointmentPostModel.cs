namespace workshop.wwwapi.DTO
{
    public class AppointmentPostModel
    {
        public DateTime Booking { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
    }
}
