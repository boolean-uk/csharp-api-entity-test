using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.Types;

[Table("appointment")]
public class Appointment
{
    [Column("id")]
    public int Id { get; set; }
    [Column("booking")]
    public DateTime Booking { get; set; }
    [Column("appointment_type")]
    public AppointmentType AppointmentType { get; set; }
    [Column("fk_doctor_id")]
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    [Column("fk_patient_id")]
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    [Column("fk_prescription_id")]
    public int? PrescriptionId { get; set; }
    public Prescription? Prescription { get; set; }
}
