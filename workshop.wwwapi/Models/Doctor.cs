using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("doctors")]
    public class Doctor
    {
        [Column("doctor_id")]
        public int Id { get; set; }
        [Column("doctor_full_name")]
        public string FullName { get; set; }

        public ICollection<Appointment> Appointments { get; set; } 
    }
}
