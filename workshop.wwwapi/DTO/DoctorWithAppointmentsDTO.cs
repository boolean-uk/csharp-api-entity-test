namespace workshop.wwwapi.DTO
{
    public class DoctorWithAppointmentsDTO
    {
        public string FullName { get; set; }

        public IEnumerable<AppointmentDTO> Appointments { get; set; }
    }
}
