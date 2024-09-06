using System.Diagnostics.Contracts;

namespace workshop.wwwapi.Models
{
    public class CreateMedicinePerscriptionDto
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public string Note { get; set; }
       public int Quantity { get; set; }
    }
}
