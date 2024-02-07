using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTOs.Extension
{
    public class MedicineDTO_L2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Instruction { get; set; }
        public ICollection<MedicinePrescriptionDTO> MedicinePrescriptions { get; set; } = new List<MedicinePrescriptionDTO>();
    }
}
