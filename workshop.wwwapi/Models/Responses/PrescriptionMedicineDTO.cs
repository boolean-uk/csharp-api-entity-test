namespace workshop.wwwapi.Models.Responses
{
    public class PrescriptionMedicineDTO
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
