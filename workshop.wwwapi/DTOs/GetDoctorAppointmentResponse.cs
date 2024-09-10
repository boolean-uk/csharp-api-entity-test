namespace workshop.wwwapi.DTOs
{
    public class GetDoctorAppointmentResponse
    {
        public List<DTODoctorAppointment> Appointments { get; set; } = new List<DTODoctorAppointment>();
    }
}
