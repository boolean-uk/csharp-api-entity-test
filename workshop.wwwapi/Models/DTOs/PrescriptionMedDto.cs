namespace workshop.wwwapi.Models.DTOs
{
    public class PrescriptionMedDto
    {
       
    public int Id { get; set; }
        public int MedicineId { get; set; }
        public int PrescriptionId { get; set; }
        // Other properties as needed

        // Additional constructor to map from PrescriptionMedicine entity to PrescriptionMedicineDTO
        public PrescriptionMedDto(PrescriptionMedicine prescriptionMedicine)
        {
            MedicineId = prescriptionMedicine.MedicineId;
            PrescriptionId = prescriptionMedicine.PrescriptionId;
            // Map other properties as needed
        }
    }
}
