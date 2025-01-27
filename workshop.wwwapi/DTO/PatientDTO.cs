using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PatientDTO
    {
        private List<Patient> patient;

        public int Id { get; set; }
        public string FullName { get; set; }
        public List<string> Appointments { get; set; } = new List<string>();
        public PatientDTO() { }
        public PatientDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
            //making string representation of Appointments
            patient.Appointments.ForEach(a => Appointments.Add($"Patient: {FullName}, Doctor: {a.Doctor.FullName}, Time: {a.Booking}"));
        }

    }
    
}
