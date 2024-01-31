
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO {

    public class PatientDTOResponse {
        public int Id {get; set;}
        public string FullName {get; set;}
        public ICollection<DoctorAppointmentDTO> Appointments {get; set;}

        public PatientDTOResponse(Patient patient) {
            Id = patient.Id;
            FullName = patient.FullName;
            Appointments = DoctorAppointmentDTO.FromRepository(patient.Appointments);
        }

        public static ICollection<PatientDTOResponse> FromRepository(IEnumerable<Patient> patients) {
            List<PatientDTOResponse> result = new List<PatientDTOResponse>();
            foreach (Patient patient in patients)
            {
                result.Add(new PatientDTOResponse(patient));
            }
            return result;

        }


    }
}