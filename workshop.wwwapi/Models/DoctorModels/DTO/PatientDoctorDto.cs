using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DoctorModels.DTO
{
    public class PatientDoctorDto
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
    }
}
