using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required Appointment Appointment { get; set; }
    [Required]
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    
    [JsonIgnore]
    public ICollection<PrescriptionMedicine> Items { get; set; } = new List<PrescriptionMedicine>();
}