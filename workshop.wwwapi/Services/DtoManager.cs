using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTO;

namespace workshop.wwwapi.Services
{
    public class DtoManager
    {
        public static OutputPatient Convert(Patient patient)
        {
            return new OutputPatient
            {
                Id = patient.Id,
                FullName = patient.FullName
            };
        }
        public static IEnumerable<OutputPatient> Convert(IEnumerable<Patient> patients)
        {
            return patients.Select(patient => Convert(patient));
        }

        public static Patient Convert(InputPatient inputPatient)
        {
            return new Patient
            {
                FullName = inputPatient.FullName
            };
        }

    }
}
