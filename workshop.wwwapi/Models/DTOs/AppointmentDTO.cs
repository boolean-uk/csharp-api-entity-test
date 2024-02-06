namespace workshop.wwwapi.Models.DTOs
{
    public class AppointmentDTO
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public DateTime Booking {  get; set; }

        public string PatientName { get; set; }

        public string DoctorName { get; set; } 
    }
}
