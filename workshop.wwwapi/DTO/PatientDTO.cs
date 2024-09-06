namespace workshop.wwwapi.DTO
{
    public class PatientDTO
    {
        public string Name { get; set; }
        public List<PatientAppointments> Appointments { get; set; } = new List<PatientAppointments>();
    }
}
