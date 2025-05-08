namespace workshop.wwwapi.Models.DTOs
{
    public class PostAppointment
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public DateTime Booking { get; set; }


    }
}
