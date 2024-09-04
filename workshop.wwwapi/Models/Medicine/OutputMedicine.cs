using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class OutputMedicine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Notes { get; set; }

        public IEnumerable<PrescriptionWhitoutMedicine> Prescriptions { get; set; }
    }
}
