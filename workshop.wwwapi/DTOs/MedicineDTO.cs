using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class MedicineDTO
    {
        public MedicineDTO(string name, string notes, int quantity)
        {
            Name = name;
            Notes = notes;
            Quantity = quantity;
        }
        public string Name { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
