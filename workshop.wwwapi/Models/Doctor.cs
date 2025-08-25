using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models;

[Table("Doctor")]
public class Doctor
{
    [Column("id")]
    [Key]
    public int Id { get; set; }
    
    [Column("full_name")]
    [Required]
    public required string FullName { get; set; }
    
    [Column("appointments")]
    [JsonIgnore]
    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    
}

