namespace workshop.wwwapi.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<PatientAppointmentDTO> Appointments { get; set; } //holds name, id, name, id

        public PatientDTO(int id, string name)
        {
            Id = id;
            FullName = name;
            Appointments = new List<PatientAppointmentDTO>(); // initialize list in constructor
        }
    }
}
