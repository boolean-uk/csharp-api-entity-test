using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    [Table("prescription")]
    public class Prescription
    {
        
            [Column("id")]          //By convention, a property named Id or <type name>Id will be configured as the primary key of an entity.
            [Key]
            public int Id { get; set; }


            public ICollection<PrescriptionMedicine> PrescriptMed { get; set; } = new List<PrescriptionMedicine>();       

        
    }
}
