namespace workshop.wwwapi.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string Instruction { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public List<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
