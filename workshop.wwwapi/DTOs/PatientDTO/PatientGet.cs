namespace workshop.wwwapi.DTOs.PatientDTO
{
    public class PatientGet
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<PatientAppointmentGet> Appointments { get; set; } = new List<PatientAppointmentGet>();
    }
}
