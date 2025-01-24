namespace workshop.wwwapi.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public ICollection<AppointmentdoctorDTO> Appointments { get; set; } = new List<AppointmentdoctorDTO>();
    }
}
