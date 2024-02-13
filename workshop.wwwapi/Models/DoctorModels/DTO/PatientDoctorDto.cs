using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.PatientModels;

namespace workshop.wwwapi.Models.DoctorModels.DTO
{
    public class PatientDoctorDto
    {
        public int PatientId { get; set; }
        public string Name { get; set; }

        public static PatientDoctorDto Create(Patient patient)
        {
            return new PatientDoctorDto()
            {
                PatientId = patient.Id,
                Name = patient.FullName
            };
        }
    }
}
