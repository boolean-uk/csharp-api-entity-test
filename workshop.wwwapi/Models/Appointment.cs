using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models;

//[PrimaryKey(nameof(DoctorId), nameof(PatientId))]
[PrimaryKey(nameof(Id))]
[Table("appointments")]
public class Appointment
{
    [Column("id")]
    public int Id { get; set; }

    [Column("booking")]
    public DateTime Booking { get; set; }

    [Column("appointment_type")]
    public AppointmentType AppointmentType { get; set; }

    [Column("doctor_id")]
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    [Column("patient_id")]
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AppointmentType
{
    Physical,
    Digital,
}
