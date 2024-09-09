namespace workshop.wwwapi.DTOs
{
    public class GetPatientsResponse
    {
        public List<DTOPatient> Patients { get; set; } = new List<DTOPatient>();
    }
}
