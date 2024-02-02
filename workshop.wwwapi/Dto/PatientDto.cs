namespace workshop.wwwapi.Dto
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }
}
