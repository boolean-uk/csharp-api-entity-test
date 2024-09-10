using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.ViewModel
{
    public class MedicineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Instruction { get; set; }

        public MedicineDTO(Medicine medicine)
        {
            this.Id = medicine.Id;
            this.Name = medicine.Name;
            this.Quantity = medicine.Quantity;
            this.Instruction = medicine.Instruction;
        }
    }
}
