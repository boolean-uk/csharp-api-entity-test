namespace workshop.wwwapi.Models.DTObjects
{
    public class DTPatient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DTAppointment> Appointments { get; set; }
    }
}
