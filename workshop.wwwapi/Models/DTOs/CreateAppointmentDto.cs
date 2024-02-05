namespace workshop.wwwapi.Models.DTOs
{
    public class CreateAppointmentDto
    {

        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime AppointmentTime { get; set; }

    }
}
