using workshop.wwwapi.Models.PrescriptionMedicineModels;

namespace workshop.wwwapi.Models.MedicineModels
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }

}
