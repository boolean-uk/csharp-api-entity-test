using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("doctors")]
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Column("name")]
        public string FullName { get; set; }

        [Column("Appointments")]
        [JsonIgnore]
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        [Column("prescriptionId")]
        public int prescriptionId { get; set; }

        [Column("prescription")]
        public Prescription Prescription { get; set; }
    }
}
