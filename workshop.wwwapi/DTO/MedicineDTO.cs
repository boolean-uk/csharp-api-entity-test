using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTO
{
    public class MedicineDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
