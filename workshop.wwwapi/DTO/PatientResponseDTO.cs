using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Models
{
    public class PatientResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public ICollection<PatientAppointmentDTO> Appointments { get; set; } = new List<PatientAppointmentDTO>();

        public PatientResponseDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
            if (patient.Appointments != null)
            {
                foreach (Appointment appointment in patient.Appointments)
                {
                    Appointments.Add(new PatientAppointmentDTO(appointment));
                }
            }


        }

        public static List<PatientResponseDTO> FromRepository(IEnumerable<Patient> patients)
        {
            var results = new List<PatientResponseDTO>();
            foreach (var patient in patients)
            {
                results.Add(new PatientResponseDTO(patient));
            }
            return results;
        }

        public static PatientResponseDTO FromRepository(Patient patient)
        {
            return new PatientResponseDTO(patient);
        }

    }
}