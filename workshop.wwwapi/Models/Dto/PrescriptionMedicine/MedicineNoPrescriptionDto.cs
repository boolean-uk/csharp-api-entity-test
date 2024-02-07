using workshop.wwwapi.Models.Dto.Medicine;

namespace workshop.wwwapi.Models.Dto.PrescriptionMedicine
{
    public class MedicineNoPrescriptionDto
    {
        public int MedicineId { get; set; }
        //public int PerscriptionId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public MedicinePlainDto Medicine { get; set; }
        //public PrescriptionDto Prescription { get; set; }
    }
}
