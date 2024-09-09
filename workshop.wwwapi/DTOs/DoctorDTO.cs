namespace workshop.wwwapi.DTOs
{
    public class DoctorDTO
    {

        public int id { get; set; }

        public string fullName { get; set; }

        public List<PatientAppointmentDTO> appointments { get; set; }
    }
}
