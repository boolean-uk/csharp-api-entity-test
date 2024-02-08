using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models;

[Table("prescriptions")]
public class Prescription
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    public ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}