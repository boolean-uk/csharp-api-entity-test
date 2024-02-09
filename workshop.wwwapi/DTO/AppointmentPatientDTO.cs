using System.Text.Json.Serialization;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentPatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AppointmentPatientDTO(Patient patient) 
        {
            Id = patient.Id;
            Name = patient.FullName;
        }
        [JsonConstructor]
        public AppointmentPatientDTO()
        {
            
        }
    }
}
