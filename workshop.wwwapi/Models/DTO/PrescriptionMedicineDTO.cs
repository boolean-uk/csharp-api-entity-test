namespace workshop.wwwapi.Models.DTO
{
    public class PrescriptionMedicineDTO
    {
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
