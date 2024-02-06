namespace workshop.wwwapi.DTOs.Core
{
    public class PatientDTO_L2
    {
        public string FullName { get; set; }
        public List<AppointmentDTO_P1> Appointments { get; set; } = new List<AppointmentDTO_P1>();
    }
}
