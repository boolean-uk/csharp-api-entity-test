using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models;

[Table("Appointment")]
public class Appointment
{
    [Key]
    public int AppointmentId { get; set; }
    
    [Column("doctor_fk")]
    [Required]
    public int DoctorId { get; set; }
    
    [JsonIgnore]
    public virtual Doctor Doctor { get; set; }

    [Column("patient_fk")]
    [Required]
    public int PatientId { get; set; }
    [JsonIgnore]
    public virtual Patient Patient { get; set; }
    
    [Column("booking_time")]
    [Required]
    public DateTime AppointmentDate { get; set; }
    
    [Column("prescriptions")]
    [JsonIgnore]
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    
}
