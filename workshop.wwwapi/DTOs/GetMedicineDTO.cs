using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTOs
{
    public class GetMedicineDTO
    {
        public string Name { get; set; }
        public string Instruction { get; set; }
        public int Quantity { get; set; }
    }
}
