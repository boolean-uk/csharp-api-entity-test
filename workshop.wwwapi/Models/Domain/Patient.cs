using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models.Domain
{
    [Table("patients")]
    public class Patient
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; }
    }
}
