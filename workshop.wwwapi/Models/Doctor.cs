using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("doctors")]
    public class Doctor
    {
        private static int _id = 1;
        public Doctor()
        {
            Id = _id++;
        }

        [Key]
        [Column("id")]
        public int Id { get; internal set; }
        [Column("name")]
        public string FullName { get; set; }

        public ICollection<Appointment> appointments { get; set; } = new List<Appointment>();
    }
}
