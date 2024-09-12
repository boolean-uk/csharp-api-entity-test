namespace workshop.wwwapi.DTO
{
    public class GetPatientsResponse
    {
        public List<GetPatientDTO> Patients { get; set; } = new List<GetPatientDTO>();
    }
}
