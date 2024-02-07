using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models;

[Table("medicines")]
public class Medicine
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; }
}
