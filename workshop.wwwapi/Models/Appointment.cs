using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models;

[Table("appointment")]
public class Appointment
{
    [Column("booking")]
    public DateTime Booking { get; set; }
    [Column("ppk_doctor_id")]
    [Key]
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    [Column("ppk_patient_id")]
    [Key]
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
}
