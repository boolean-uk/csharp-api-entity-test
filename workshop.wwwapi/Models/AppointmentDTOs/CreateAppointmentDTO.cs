namespace workshop.wwwapi.Models.AppointmentDTOs
{
    public class CreateAppointmentDTO
    {
        public Guid PatientId { get; set; } 
        public Guid DoctorId { get; set; }   
        public DateTime AppointmentDate { get; set; }
    }
}
