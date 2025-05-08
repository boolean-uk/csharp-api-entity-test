namespace workshop.wwwapi.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Instructions { get; set; }

        public ICollection<Perscription> Perscription { get; set; }
    }
}
