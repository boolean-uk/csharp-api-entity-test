namespace workshop.wwwapi.Models.DTOs
{
    public class AppointmentDTO
    {
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}
