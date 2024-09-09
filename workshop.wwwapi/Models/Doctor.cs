using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("doctors")]
    public class Doctor
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
