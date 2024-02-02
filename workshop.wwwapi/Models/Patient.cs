using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    

    [Table("patient")]
    public class Patient
    {
        [Column("id")]          //By convention, a property named Id or <type name>Id will be configured as the primary key of an entity.
        [Key]
        public int Id { get; set; }
        
        [Column("fullname")]
        public string FullName { get; set; }
    }
}
