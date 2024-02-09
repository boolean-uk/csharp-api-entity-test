using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PrescriptionWithMedicineDTO
    {

        public int PrescriptionId { get; set; }
        public string? Notes { get; set; }
        public ICollection<MedicineDTO> Medicines { get; set; }


        public PrescriptionWithMedicineDTO(Prescription prescription)
        {
            PrescriptionId = prescription.PrescriptionId;
            Notes = prescription.Notes ?? "No note given";

            Medicines = prescription.PrescriptionMedicines
                .Select(m => new MedicineDTO(m.Medicine)).ToList();

            
        }
        
    }
}
