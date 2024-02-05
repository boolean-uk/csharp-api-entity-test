using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    [PrimaryKey(nameof(PrescriptionId), nameof(MedicineId))]
    public class PrescriptionMedicine
    {
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
    }
}
