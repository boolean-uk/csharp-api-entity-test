using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public PatientDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
        }
    }
}
