namespace workshop.wwwapi.Models;

public class PostPrescription
{
    public string Name { get; set; }
    public ICollection<PostMedicinePrescription> MedicinePrescriptions { get; set; }
}
