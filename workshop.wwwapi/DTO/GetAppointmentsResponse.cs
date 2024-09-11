namespace workshop.wwwapi.DTO
{
    public class GetAppointmentsResponse
    {
        public ICollection<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();
    }
}
