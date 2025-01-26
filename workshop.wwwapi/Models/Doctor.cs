namespace workshop.wwwapi.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; }

    }
}

