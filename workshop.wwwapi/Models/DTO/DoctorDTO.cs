namespace workshop.wwwapi.Models.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<AppointmentDTO> Appointments { get; set; }

        public DoctorDTO(int id, string fullName, List<AppointmentDTO> appointments)
        {
            Id = id;
            FullName = fullName;
            Appointments = appointments;
        }
    }
}
