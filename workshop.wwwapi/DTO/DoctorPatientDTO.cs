using System.Text.Json.Serialization;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class DoctorPatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DoctorPatientDTO(Patient patient) 
        {
            Id = patient.Id;
            Name = patient.FullName;
        }
        [JsonConstructor]
        public DoctorPatientDTO()
        {
            
        }
    }
}
