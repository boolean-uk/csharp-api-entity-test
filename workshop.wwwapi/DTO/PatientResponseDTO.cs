using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public ICollection<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();

        public PatientResponseDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
            foreach (var appointment in patient.Appointments)
                Appointments.Add(new AppointmentDTO(appointment));
        }

        public static List<PatientResponseDTO> FromRepository(IEnumerable<Patient> patients)
        {
            var results = new List<PatientResponseDTO>();
            foreach (var patient in patients)
                results.Add(new PatientResponseDTO(patient));
            return results;
        }

        public static PatientResponseDTO FromARepository(Patient patient)
        {
            PatientResponseDTO result = new PatientResponseDTO(patient);
            return result;
        }
    }
}
