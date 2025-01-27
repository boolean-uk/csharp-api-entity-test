namespace workshop.wwwapi.DTO
{
    public class PatientWithAppointmentsDTO
    {
        public string FullName { get; set; }

        public IEnumerable<AppointmentDTO> Appointments { get; set; }
    }
}
