namespace workshop.wwwapi.DTO
{
    public class GetAppointmentsResponse
    {
        public List<AllAppointmentsDTO> Appointments { get; set; } = new List<AllAppointmentsDTO>();
    }
}
