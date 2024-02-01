
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models {

    [Table("medicines")]
    public class Medicine {
        [Column("id")]
        public int Id {get; set;}
        [Column("name")]
        public required string Name {get; set;}
        [Column("description")]
        public required string Description {get; set;}
        [Column("quantity")]
        public int Quantity {get; set;}

        public ICollection<Prescription> Prescriptions {get; set;} = [];

    }
}