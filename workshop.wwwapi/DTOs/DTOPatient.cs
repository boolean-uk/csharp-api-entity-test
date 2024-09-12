namespace workshop.wwwapi.DTOs
{
    public class DTOPatient
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<DTOAppointmentWithoutPatient> Appointments { get; set; } = new List<DTOAppointmentWithoutPatient>();
    }
}
