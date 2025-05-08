using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.DoctorModels;

namespace workshop.wwwapi.Models.PatientModels.DTO
{

    public class DoctorPatientDto
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }

        public static DoctorPatientDto Create(Doctor doctor)
        {
            return new DoctorPatientDto()
            {
                DoctorId = doctor.Id,
                Name = doctor.FullName
            };
        }
    }
}
