using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientOnlyDTO
    {
        public string patient_full_name { get; set; }

        public PatientOnlyDTO(Patient patient) {
            patient_full_name = patient.FullName;
        }
    }
}
