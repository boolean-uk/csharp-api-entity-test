namespace workshop.wwwapi.DTOs
{
    public class ResponsePatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<ResponseDoctorAppointmentDTO> Appointments { get; set; } = new List<ResponseDoctorAppointmentDTO>();
    }

    public class PostPatientDTO
    {
        public string FullName { get; set; }
    }
}
