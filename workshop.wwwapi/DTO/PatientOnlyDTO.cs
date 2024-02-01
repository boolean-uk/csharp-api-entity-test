using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientOnlyDTO
    {
        public int Id { get; set; }
        public string patient_full_name { get; set; }

        public PatientOnlyDTO(Patient patient) {
            Id = patient.Id;
            patient_full_name = patient.FullName;
        }
    }
}
