namespace workshop.wwwapi.Models.DTO
{
    public class AppointmentForDoctorDTO
    {
        public DateTime Booking { get; set; }
        public int PatientId { get; set; }
        public int PrescriptionId { get; set; }
    }
    public class AppointmentForPatientDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PrescriptionId { get; set; }

    }
    public class AppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int PrescriptionId { get; set; }

    }
}
