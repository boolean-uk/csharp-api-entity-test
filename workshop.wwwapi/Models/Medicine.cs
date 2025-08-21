namespace workshop.wwwapi.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PrescribedMedicine> Prescriptions { get; set; }
    }
}
