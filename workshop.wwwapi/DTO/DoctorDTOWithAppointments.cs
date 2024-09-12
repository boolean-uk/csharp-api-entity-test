namespace workshop.wwwapi.DTO
{
    public class DoctorDTOWithAppointments
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<DoctorAppointmentDTO> Appointments { get; set; } = new List<DoctorAppointmentDTO>();
    }
}
