namespace workshop.wwwapi.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }

        public string fullName { get; set; }   

        public List<DoctorAppointmentDTO> appointments { get; set; } 
    }
}
