using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models.PureModels
{
    //TODO: decorate class/columns accordingly
    [Table("patients")]
    public class Patient
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [MaxLength(123)]
        [Column("full_name")]
        public string FullName { get; set; }
    }
}
