using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    public class Doctor
    {

        [Key]
        public int Id { get; set; }

        [Column("doctor_name")]
        public string FullName { get; set; }
        [Column("booking")]
        public List<Appointment> Appointments { get; set; }
        
    }
}
