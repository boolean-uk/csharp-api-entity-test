namespace workshop.wwwapi.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public List<Prescription> Prescriptions { get; set; } = [];
        public List<MedicinePrescription> MedicinePrescriptions { get; set; } = [];
    }
}
