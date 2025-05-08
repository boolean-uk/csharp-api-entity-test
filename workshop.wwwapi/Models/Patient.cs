using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("patients")]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("fullname")]
        public string FullName { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }

    public class AppointmentPatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public AppointmentPatientDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
        }
    }
    public record PatientPayload(string Fullname);
    public class PatientResponseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<PatientAppointmentDTO> Appointments { get; set; }
        public PatientResponseDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
            Appointments = new List<PatientAppointmentDTO>();
            foreach (Appointment appointment in patient.Appointments)
            {
                Appointments.Add(new PatientAppointmentDTO(appointment));
            }
        }
    }
}
