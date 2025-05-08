using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    [Table("patients")]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
