namespace workshop.wwwapi.DTO
{
    public class DoctorListDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<AppointmentDoctorListDTO> Appointments { get; set; } = new List<AppointmentDoctorListDTO>();

    }
}
