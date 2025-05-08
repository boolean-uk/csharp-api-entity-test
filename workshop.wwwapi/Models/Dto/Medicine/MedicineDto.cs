using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.Dto.PrescriptionMedicine;

namespace workshop.wwwapi.Models.Dto.Medicine
{
    public class MedicineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PrescritptionNoMedicineDto> PrescriptionMedicine { get; set; } = new List<PrescritptionNoMedicineDto>();
    }
}
