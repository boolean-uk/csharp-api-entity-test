using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    

    [Table("patient")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string FullName { get; set; }


        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

