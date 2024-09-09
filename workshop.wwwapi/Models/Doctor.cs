using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("doctors")]
    public class Doctor
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("full_Name")]
        public string FullName { get; set; }
    }
}
