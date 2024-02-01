using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO
{
    public class PatientResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<DoctorAppointmentDTO> Appointments { get; set; }

        public PatientResponseDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
            Appointments = DoctorAppointmentDTO.FromRepository(patient.Appointments);
        }

        public static ICollection<PatientResponseDTO> FromRepository(IEnumerable<Patient> patients)
        {
            List<PatientResponseDTO> result = new List<PatientResponseDTO>();
            foreach (Patient patient in patients)
            {
                result.Add(new PatientResponseDTO(patient));
            }
            return result;

        }
    }
}
