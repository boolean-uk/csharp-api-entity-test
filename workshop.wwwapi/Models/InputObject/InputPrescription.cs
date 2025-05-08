using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.InputObject
{
    public class InputPrescription
    {
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
