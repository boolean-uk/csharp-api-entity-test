namespace workshop.wwwapi.DTO
{
    public class GetDoctorsResponse
    {
        public List<DoctorDTOWithAppointments> Doctors { get; set; } = new List<DoctorDTOWithAppointments>();
    }
}
