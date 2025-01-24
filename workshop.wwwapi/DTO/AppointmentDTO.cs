namespace workshop.wwwapi.DTO
{
    public class AppointmentDTO
    {
        public DateTime DateTime { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
    }
}
