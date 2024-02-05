namespace workshop.wwwapi.Models.DTOs
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public ICollection<DoctorAppointmentDTO> Appointments { get; set; }
    }
}
