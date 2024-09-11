using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    public class GetMedicineDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Notes { get; set; }
    }
}
