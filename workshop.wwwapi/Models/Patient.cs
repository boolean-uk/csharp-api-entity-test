using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models;

[Table("Patient")]
public class Patient
{
    [Key] public int Id { get; set; }

    [Required] public required string FullName { get; set; }

    [Column("appointments")] 
    [JsonIgnore]
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}