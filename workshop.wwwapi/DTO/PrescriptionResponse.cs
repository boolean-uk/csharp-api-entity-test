namespace workshop.wwwapi.DTO;

public class PrescriptionResponse
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public List<PrescriptionLineResponse> Lines { get; set; }
}