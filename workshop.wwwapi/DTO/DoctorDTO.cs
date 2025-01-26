namespace workshop.wwwapi.DTO
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }    

        public List<AppointmentDTO> Appointments { get; set; } 

    }
}
