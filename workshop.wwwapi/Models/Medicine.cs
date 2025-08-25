using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models;

[Table("Medicine")]
public class Medicine
{
    [Key]
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [MaxLength(512)]
    public string? Description { get; set; }

    [JsonIgnore]
    public ICollection<PrescriptionMedicine> Prescriptions { get; set; } = new List<PrescriptionMedicine>();
}