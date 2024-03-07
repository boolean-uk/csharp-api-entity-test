using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    public class Medicine
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("medname")]
        public string MedName { get; set; }
    }
}
