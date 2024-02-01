using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data.DTO
{
    public class DoctorResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<PatientAppointmentDTO> Appointments { get; set; }

        public DoctorResponseDTO(Doctor patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
            Appointments = PatientAppointmentDTO.FromRepository(patient.Appointments);
        }

        public static ICollection<DoctorResponseDTO> FromRepository(IEnumerable<Doctor> patients)
        {
            List<DoctorResponseDTO> result = new List<DoctorResponseDTO>();
            foreach (Doctor patient in patients)
            {
                result.Add(new DoctorResponseDTO(patient));
            }
            return result;

        }
    }
}
