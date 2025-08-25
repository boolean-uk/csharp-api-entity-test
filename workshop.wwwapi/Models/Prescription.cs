using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

public class Prescription
{
    public int Id { get; set; }

    [Required]
    public int AppointmentId { get; set; }

    [ForeignKey("AppointmentId")]
    public Appointment Appointment { get; set; }

    
    public ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; }
}
