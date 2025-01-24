namespace workshop.wwwapi.DTO
{
    public class GetAppointmentsResponse
    {
        public List<GetAppointmentsDTO> Appointments { get; set; } = new List<GetAppointmentsDTO>();
    }
}
