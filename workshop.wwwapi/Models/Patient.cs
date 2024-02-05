using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace workshop.wwwapi.Models
{
    //Paitent class
    [Table("patients")]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        public List<Appointment> Appointments { get; set; }
    }

    //DTO
    public class PatientResponseDTO
    {
        public int ID { get; set; }
        public string name { get; set; }
        public List<AppointmentsResponseDTO> appointments { get; set; }
        public PatientResponseDTO(Patient patient)
        {
            name = patient.FullName;
            ID = patient.Id;
            appointments = patient.Appointments?
                .Select(appointment => new AppointmentsResponseDTO(appointment))
                .ToList() ?? new List<AppointmentsResponseDTO>();
        }
    }
}