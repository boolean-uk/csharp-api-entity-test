namespace workshop.wwwapi.Models.DTO
{
    public class AppointmentForDoctorDTO
    {
        public DateTimeOffset Booking { get; set; }
        public int PatientId { get; set; }
    }
    public class AppointmentForPatientDTO
    {
        public DateTimeOffset Booking { get; set; }
        public int DoctorId { get; set; }
    }
    public class AppointmentDTO
    {
        public DateTimeOffset Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
