namespace workshop.wwwapi.DTOs
{
    public class DoctorDTO
    {
        public string FullName { get; set; }
        public List<DoctorDTO2> Appointments { get; set; } = new List<DoctorDTO2>();
    }
}
