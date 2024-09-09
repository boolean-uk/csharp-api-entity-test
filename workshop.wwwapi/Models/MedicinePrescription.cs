namespace workshop.wwwapi.Models
{
    public class MedicinePrescription
    {
        public int MedicineId { get; set; }
        public int PrescriptionId { get; set; }
        public int Count { get; set; }
        public Medicine Medicine { get; set; }
        public Prescription Prescription { get; set; }
    }
}
