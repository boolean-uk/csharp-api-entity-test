using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.DTOs
{
    public class ResponseDoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<ResponsePatientAppointmentDTO> Appointments { get; set; } = new List<ResponsePatientAppointmentDTO>();
    }

    public class PostDoctorDTO
    {
        public string FullName { get; set; }
    }
}
