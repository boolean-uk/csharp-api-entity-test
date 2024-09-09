using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("Doctor")]
    public class Doctor
    {
        [Column("id")]        
        public int Id { get; set; }

        [Column("Fullname")]
        public string FullName { get; set; }

        public List<Appointment> appointments { get; set; }
    }
}
