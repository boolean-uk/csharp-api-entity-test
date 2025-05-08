using workshop.wwwapi.Models;

namespace workshop.wwwapi.Services
{
    public class PatientDtoManager
    {
        public static OutputPatient Convert(Patient patient)
        {
            return new OutputPatient
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = AppointmentDtoManager.ConvertRemovePatient(patient.Appointments)
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
