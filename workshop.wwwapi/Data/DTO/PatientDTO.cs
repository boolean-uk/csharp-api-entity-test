
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO {

    public class PatientDTO {
        public int Id {get; set;}
        public string FullName {get; set;}

        public PatientDTO(Patient doctor) {
            Id = doctor.Id;
            FullName = doctor.FullName;
        }

        public static ICollection<PatientDTO> FromRepository(IEnumerable<Patient> doctors) {
            List<PatientDTO> result = new List<PatientDTO>();
            foreach (Patient doctor in doctors)
            {
                result.Add(new PatientDTO(doctor));
            }
            return result;

        }


    }
}