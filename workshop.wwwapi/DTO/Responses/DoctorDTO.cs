namespace workshop.wwwapi.DTO.Responses
{
    public class DoctorDTO
    {
        public string FullName { get; set; }
        public List<AppointmentDoctorDTO> Appointments { get; set; } = new List<AppointmentDoctorDTO>();
    }
}
