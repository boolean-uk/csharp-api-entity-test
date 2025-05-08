namespace workshop.wwwapi.Models
{
    public class MedicinePrescription
    {
        public int MedicineId { get; set; }
        public int PrescriptionId { get; set; }
        public Medicine Medicine { get; set; }
        public Prescription Prescription { get; set; }
        //public int Quantity { get; set; }
    }
}
