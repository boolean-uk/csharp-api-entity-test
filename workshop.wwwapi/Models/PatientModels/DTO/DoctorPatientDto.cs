using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.PatientModels.DTO
{

    public class DoctorPatientDto
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
    }
}
