namespace workshop.wwwapi.DTOs
{
    public class ResponseAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; }
        public int? PrescriptionId { get; set; }
    }

    public class ResponseDoctorAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public int? PrescriptionId { get; set; }
    }

    public class ResponsePatientAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; }
        public int? PrescriptionId { get; set; }
    }

    public class PostAppointmentDTO
    {
        public string Booking { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int? PrescriptionId { get; set; }
    }

    public class ResponseAppointmentDTOPrescriptionLess
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }
        public string DoctorFullName { get; set; }
        public int PatientId { get; set; }
        public string PatientFullName { get; set; }
    }
}
