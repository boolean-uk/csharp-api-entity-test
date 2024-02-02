namespace workshop.wwwapi.Dto
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }
}
