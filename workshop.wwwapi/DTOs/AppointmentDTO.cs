namespace workshop.wwwapi.DTOs
{
    public class AppointmentDTO
    {
        public DateTime appointmentDate {  get; set; }
        public DoctorDTO doctor { get; set; }
        public PatientDTO patient { get; set; }
    }
}
