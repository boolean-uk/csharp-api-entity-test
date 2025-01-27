using workshop.wwwapi.Enums;

namespace workshop.wwwapi.Models;

public class Appointment
{
    public int Id { get; set; }
    public AppointmentType Type { get; set; }
    public DateTime Booking { get; set; }
    public int DoctorId { get; set; }
    public virtual Doctor? Doctor { get; set; }
    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual List<Prescription>? Prescriptions { get; set; }
}