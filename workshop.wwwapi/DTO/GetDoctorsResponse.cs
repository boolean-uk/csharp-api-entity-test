namespace workshop.wwwapi.DTO
{
    public class GetDoctorsResponse
    {
        public List<GetDoctorDTO> Doctors { get; set; } = new List<GetDoctorDTO>();
    }
}
