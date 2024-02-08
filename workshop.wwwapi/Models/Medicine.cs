namespace workshop.wwwapi.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MedicinePrescription> Prescriptions { get; set; }
    }
}
