namespace workshop.wwwapi.Models;

public class Prescription
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public virtual Appointment Appointment { get; set; }
    public List<PrescriptionLine> Lines { get; set; }
}