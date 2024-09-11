namespace workshop.wwwapi.DTO
{
    public class GetPatientsResponse
    {
        public ICollection<PatientDTO> Patients { get; set; } = new List<PatientDTO>();
    }
}
