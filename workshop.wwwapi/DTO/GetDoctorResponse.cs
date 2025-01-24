namespace workshop.wwwapi.DTO
{
    public class GetDoctorResponse
    {
        public ICollection<DoctorAppointmentsDTO> Doctors { get; set; } = new List<DoctorAppointmentsDTO>();
    }
}
