namespace workshop.wwwapi.DTOs.DoctorDTO
{
    public class DoctorAppointmentGet
    {
        public int Id { get; set; }
        public DateTime Booking { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
    }
}
