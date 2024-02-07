namespace workshop.wwwapi.DTO
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public IEnumerable<AppointmentDto> Appointments { get; set; }
    }
}
