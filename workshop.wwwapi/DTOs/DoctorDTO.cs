namespace workshop.wwwapi.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DoctorAppointmentsDTO
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<AppointmentForDoctorDTO> Appointments { get; set; } = new List<AppointmentForDoctorDTO>();
    }
}
