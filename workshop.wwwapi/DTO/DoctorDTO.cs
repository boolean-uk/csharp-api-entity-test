namespace workshop.wwwapi.DTO
{
    public class DoctorDTO
    {
        public string Name { get; set; }
        public List<DoctorAppointments> Appointments { get; set; } = new List<DoctorAppointments>();
    }
}
