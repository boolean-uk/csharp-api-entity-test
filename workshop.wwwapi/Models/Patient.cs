using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("patients")]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]
        public string LastName { get; set; }
    }
}
