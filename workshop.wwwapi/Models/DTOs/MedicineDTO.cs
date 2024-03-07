using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DTOs
{
    public class MedicineDTO
    { 
        public string MedName { get; set; }

        public int Amount { get; set; }
    }
}
