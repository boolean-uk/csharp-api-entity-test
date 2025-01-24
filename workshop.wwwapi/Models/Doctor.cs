using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    

    [Table("doctors")]
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public string FullName { get; set; }

        //[ForeignKey(nameof(Appointments))]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();


    }
}
