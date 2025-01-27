namespace workshop.wwwapi.DTO;

public class PrescriptionPost
{
    public int AppointmentId { get; set; }
    public List<PrescriptionLinePost> Lines { get; set; }
}