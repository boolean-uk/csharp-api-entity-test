using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.DTO;

namespace workshop.wwwapi.Models
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public PatientDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
        }

    }
}