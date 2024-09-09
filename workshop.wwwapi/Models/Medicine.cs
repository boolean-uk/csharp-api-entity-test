using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    [Table("medicine")]
    public class Medicine
    {
            [Column("id")]          //By convention, a property named Id or <type name>Id will be configured as the primary key of an entity.
            [Key]
            public int Id { get; set; }

            [Column("name")]
            public string Name{ get; set; }

           public ICollection<PrescriptionMedicine> PrescriptMed { get; set; } = new List<PrescriptionMedicine>();        //COMMENT: This does not generate a column on the table actually!
       
    }
}
