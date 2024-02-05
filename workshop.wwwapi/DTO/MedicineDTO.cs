using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class MedicineDTO
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string Notes { get; set; }

        public MedicineDTO(Medicine medicine)
        {
            Id = medicine.Id;
            Quantity = medicine.Quantity;
            Notes = medicine.Notes;
        }
    }
}