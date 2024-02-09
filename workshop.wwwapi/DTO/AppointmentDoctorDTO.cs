using System.Text.Json.Serialization;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentDoctorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public AppointmentDoctorDTO(Doctor doctor) 
        {
            Id = doctor.Id;
            Name = doctor.FullName;
        }
        [JsonConstructor]
        public AppointmentDoctorDTO()
        {
            
        }
    }
}
