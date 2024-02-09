using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PrescriptionWithMedicineDTO
    {

        public int PrescriptionId { get; set; }
        public string? Notes { get; set; }
        public ICollection<PrescriptionMedicineDTO> PrescriptionMedicines { get; set; }


        public PrescriptionWithMedicineDTO(Prescription prescription)
        {
            PrescriptionId = prescription.PrescriptionId;
            Notes = prescription.Notes ?? "No note given";

            PrescriptionMedicines = prescription.PrescriptionMedicines
                .Select(pm => new PrescriptionMedicineDTO(pm)).ToList();
               

            
        }
        
    }


    public class PrescriptionMedicineDTO
    {
        public int MedicineId { get; set; }
        public MedicineDTO Medicine { get; set; }
        public int? Quantity { get; set; }
        public string? Notes { get; set; }

        public PrescriptionMedicineDTO(PrescriptionMedicine prescriptionMedicine)
        {
            MedicineId = prescriptionMedicine.MedicineId;
            Medicine = new MedicineDTO(prescriptionMedicine.Medicine);
            Quantity = prescriptionMedicine.Quantity;
            Notes = prescriptionMedicine.Notes;
        }
    }
}
