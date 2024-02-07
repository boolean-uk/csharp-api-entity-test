namespace workshop.wwwapi.Models.DTOS
{
    public class PatientBaseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public PatientBaseDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
        }
    }
}
