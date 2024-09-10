using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("Patient")]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("FullName")]
        public string FullName { get; set; }

        public List<Appointment> appointments { get; set; }
    }
}
