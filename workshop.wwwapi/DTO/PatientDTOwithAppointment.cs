namespace workshop.wwwapi.DTO
{
    public class PatientDTOwithAppointments
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<PatientAppointmentDTO> PatientAppointments { get; set; }
    }
}
