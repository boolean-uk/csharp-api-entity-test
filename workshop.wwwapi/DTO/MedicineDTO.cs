using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class MedicineDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
        public string? Description { get; set; }

        public MedicineDTO(Medicine medicine) {
            Id = medicine.MedicineId;
            Name = medicine.Name;
            Description = medicine.Description; 
        }
    }
}
