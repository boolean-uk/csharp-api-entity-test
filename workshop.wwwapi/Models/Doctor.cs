using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("doctors")] 
    public class Doctor
    {        
        [Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string FullName { get; set; }
        
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
