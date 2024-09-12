namespace workshop.wwwapi.DTOs
{
    public class DTODoctor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<DTOAppointmentWithoutDoctor> Appointments { get; set; } = new List<DTOAppointmentWithoutDoctor>();
    }
}
