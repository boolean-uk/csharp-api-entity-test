namespace workshop.wwwapi.Models
{
    public class PrescribedMedicine
    {
        public int PrescriptionId { get; set; }
        public Prescription Prescription { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
