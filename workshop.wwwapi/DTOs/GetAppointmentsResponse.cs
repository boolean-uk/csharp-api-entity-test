namespace workshop.wwwapi.DTOs
{
    public class GetAppointmentsResponse
    {
        public List<DTOAppointment> Appointments { get; set; } = new List<DTOAppointment>();
    }
}
