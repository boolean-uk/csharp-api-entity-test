using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models.DatabaseModels
{
    [Table("patients")]
    public class Patient
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }

        [Column("appointments")]
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
