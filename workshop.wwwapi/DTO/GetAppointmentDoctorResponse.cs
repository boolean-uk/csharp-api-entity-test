namespace workshop.wwwapi.DTO
{
    public class GetAppointmentDoctorResponse
    {
        public ICollection<AppointmentDoctorDTO> Appointments { get; set; } = new List<AppointmentDoctorDTO>();
    }
}
