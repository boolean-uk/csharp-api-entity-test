namespace workshop.wwwapi.Models
{
    public class OutputDoctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public IEnumerable<AppointmentWhithoutDoctor> Appointments { get; set; }
    }
}
