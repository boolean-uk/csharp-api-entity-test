namespace workshop.wwwapi.Models.DTO
{
    public class PatientDTO
    {
        public string PatientName { get; set; }

        public IEnumerable<AppointmentPasientDto> Appointments { get; set; } = new List<AppointmentPasientDto>();
    }
}
