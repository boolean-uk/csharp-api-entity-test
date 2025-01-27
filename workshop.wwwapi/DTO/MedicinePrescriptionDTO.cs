namespace workshop.wwwapi.DTO
{
    public class MedicinePrescriptionDTO
    {
        public MedicineDTO Medicine { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
