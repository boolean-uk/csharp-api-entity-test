namespace workshop.wwwapi.Models.DTOS
{
    public class PatientDTO
    {
        public string FullName { get; set; }

        public PatientDTO(Patient patient)
        {
            FullName = patient.FullName;
        }
    }
}
