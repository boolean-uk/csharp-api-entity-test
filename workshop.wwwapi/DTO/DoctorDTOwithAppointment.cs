namespace workshop.wwwapi.DTO
{
    public class DoctorDTOwithAppointment
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public List<DoctorAppointmentDTO> DoctorAppointments { get; set; } = new List<DoctorAppointmentDTO>();
    }
}
