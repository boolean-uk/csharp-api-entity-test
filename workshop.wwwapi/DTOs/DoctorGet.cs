namespace workshop.wwwapi.DTOs
{
    public class DoctorGet
    {
        public string FullName { get; set; }
        public ICollection<DoctorAppointmentGet> Appointments { get; set; } = new List<DoctorAppointmentGet>();
    }
}
