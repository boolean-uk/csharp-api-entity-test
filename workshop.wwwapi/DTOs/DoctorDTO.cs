namespace workshop.wwwapi.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<DoctorAppointmentDTO> Appointments { get; set; }
    }
}
