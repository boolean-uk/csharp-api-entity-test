namespace workshop.wwwapi.DTO
{
    // - an appointment should include the patient's name / id
    // and the doctor's name / id
    public class AppointmentDTO 
    {
        public DateTime Booking { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

    }
}
