using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    public record CreatePatientPayload(string FullName);
    //TODO: decorate class/columns accordingly
    [Table("patients")]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
