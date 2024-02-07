namespace workshop.wwwapi.Models.DTO
{
    public class DoctorDTO
    {
        public string FullName { get; set; }

        // Navigation property for appointments
        public List<AppointmentForDoctorDTO> Appointments { get; set; } = new List<AppointmentForDoctorDTO>();
    }
    public class DoctorNameDTO
    {
        public string FullName { get; set; }
    }
}
