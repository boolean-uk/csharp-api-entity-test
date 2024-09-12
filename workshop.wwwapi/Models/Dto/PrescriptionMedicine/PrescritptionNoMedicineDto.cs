using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.Dto.Medicine;
using workshop.wwwapi.Models.Dto.Prescription;

namespace workshop.wwwapi.Models.Dto.PrescriptionMedicine
{
    public class PrescritptionNoMedicineDto
    {
        public int PerscriptionId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        //public MedicineDto Medicine { get; set; }
        public PrescriptionPlainDto Prescription { get; set; }
    }
}
