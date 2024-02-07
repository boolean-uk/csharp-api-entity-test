namespace workshop.wwwapi.Models.DataTransfer.PrescriptionMedicine
{
    public class PrescriptionMedicineInsertDTO
    {
        public int MedicineID { get; set; }
        public int Quantity { get; set; }
        public string InstructionsFromDoctor { get; set; }
    }
}
