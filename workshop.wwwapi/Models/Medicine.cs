using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace workshop.wwwapi.Models
{
    //medicine
    [Table("medicines")]
    public class Medicine
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("quantity")]
        public int quantity { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        public ICollection<MedicinePrescription> medicinePrescriptions { get; set; }
    }
}
