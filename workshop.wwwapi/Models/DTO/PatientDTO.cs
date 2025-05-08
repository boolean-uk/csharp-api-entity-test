namespace workshop.wwwapi.Models.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<AppointmentDTO> Appointments { get; set; }

        public PatientDTO(int id, string fullname, List<AppointmentDTO> appointents)
        {
            Id = id;
            FullName = fullname;
            Appointments = appointents;
        }
    }
}
