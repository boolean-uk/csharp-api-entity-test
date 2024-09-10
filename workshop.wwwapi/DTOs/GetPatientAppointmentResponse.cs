namespace workshop.wwwapi.DTOs
{
    public class GetPatientAppointmentResponse
    {
        public List<DTOPatientAppointment> Appointments { get; set; } = new List<DTOPatientAppointment>();
    }
}
