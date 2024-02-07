using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models;

[Table("prescriptions")]
public class Prescription
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    public Appointment Appointment { get; set; }
    public ICollection<MedicinePrescription> MedicinePrescriptions { get; set; }
}
