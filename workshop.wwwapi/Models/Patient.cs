using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("patients")]
    public class Patient
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        [Required]
        public string FirstName { get; set; }
        [Column("last_name")]
        [Required]
        public string LastName { get; set; }
    }
}
