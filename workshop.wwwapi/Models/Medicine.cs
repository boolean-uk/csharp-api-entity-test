namespace workshop.wwwapi.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public List<PrescriptionMedicine> PrescriptionMedicines { get; set; } = [];
    }
}
