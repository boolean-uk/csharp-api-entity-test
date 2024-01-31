
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO {

    public class DoctorDTOResponse {
        public int Id {get; set;}
        public string FullName {get; set;}
        public ICollection<PatientAppointmentDTO> Appointments {get; set;}

        public DoctorDTOResponse(Doctor patient) {
            Id = patient.Id;
            FullName = patient.FullName;
            Appointments = PatientAppointmentDTO.FromRepository(patient.Appointments);
        }

        public static ICollection<DoctorDTOResponse> FromRepository(IEnumerable<Doctor> patients) {
            List<DoctorDTOResponse> result = new List<DoctorDTOResponse>();
            foreach (Doctor patient in patients)
            {
                result.Add(new DoctorDTOResponse(patient));
            }
            return result;

        }


    }
}