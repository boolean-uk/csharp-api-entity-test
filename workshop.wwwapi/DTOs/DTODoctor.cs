namespace workshop.wwwapi.DTOs
{
    public class DTODoctor
    {
        public string DoctorName { get; set; }
        
        public List<DTODoctorAppointment> Appointments { get; set; } = new List<DTODoctorAppointment>();

    }
}
