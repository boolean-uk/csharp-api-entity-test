namespace workshop.wwwapi.DTO
{
    public class GetAppointmentPasientResponse
    {
        public ICollection<AppointmentPatientDTO> Appointments { get; set; } = new List<AppointmentPatientDTO>();
    }
}
