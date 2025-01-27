namespace workshop.wwwapi.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<AppointmentWithPatient> appointments { get; set; }

    }
}
