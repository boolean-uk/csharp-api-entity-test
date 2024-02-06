namespace workshop.wwwapi.Models.Domain.JunctionModels.PrescriptionMedicine
{
    public class PrescriptionMedicineID
    {
        public PrescriptionMedicineID(int prescriptionID, int medicineID)
        {
            PrescriptionID = prescriptionID;
            MedicineID = medicineID;
        }

        public int PrescriptionID { get; set; }
        public int MedicineID { get; set; }
    }
}
