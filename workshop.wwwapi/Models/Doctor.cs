using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.Prescriptions;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("doctors")]
    public class Doctor
    {
        [Key, Column("id", Order = 0)]
        public int Id { get; internal set; }
        [Column("name")]
        public string FullName { get; set; }

        //public Appointment appointment { get; set; } = null;
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
