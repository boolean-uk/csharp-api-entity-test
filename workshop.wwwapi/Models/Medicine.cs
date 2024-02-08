namespace workshop.wwwapi.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }

        public List<Prescription> Prescriptions { get; } = [];
    }
}