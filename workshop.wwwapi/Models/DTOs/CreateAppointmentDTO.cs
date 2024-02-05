namespace workshop.wwwapi.Models.DTOs
{
    public class CreateAppointmentDTO
    {
        public int DoctorId { get; set; }

        public int PatientId { get; set; }
        public DateTime BookingTime { get; set; }
        public AppointmentType Type { get; set; } = AppointmentType.InPerson; //default should be in person
    }
}
