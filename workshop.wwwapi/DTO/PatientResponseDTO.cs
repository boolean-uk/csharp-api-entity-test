using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        // TODO: Make Appointment to an AppointmentDTO? 
        public ICollection<PatientAppointmentDTO> Appointments { get; set; } = new List<PatientAppointmentDTO>();

        public PatientResponseDTO(Patient patient) 
        { 
            Id = patient.Id;
            FullName = patient.FullName;
            Email = patient.Email;


            Appointments = new List<PatientAppointmentDTO>();
            foreach (var appointment in patient.Appointments)
            {
                Appointments.Add(new PatientAppointmentDTO(appointment));
            }
        }

        // for creating a list of patients
        public static List<PatientResponseDTO> FromRepository(IEnumerable<Patient> patients)
        {
            var results = new List<PatientResponseDTO>();
            foreach (var patient in patients)
            {
                results.Add(new PatientResponseDTO(patient));
            }
            return results;
        }

        // for creating a patient.
        public static PatientResponseDTO FromRepository(Patient patient)
        {
            return new PatientResponseDTO(patient);
        }
    }
}
