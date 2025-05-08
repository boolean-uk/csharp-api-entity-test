namespace workshop.wwwapi.Models
{
    public class Perscription
    {
        public int Id { get; set; }

        public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }


    }
}
