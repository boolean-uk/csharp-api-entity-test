using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Models.PatientModels;

namespace workshop.wwwapi.Models.AppointmentModels.DTO
{
    public class PatientAppointmentDto
    {
        public int PatientId { get; set; }
        public string Name { get; set; }

        public static PatientAppointmentDto Create(Patient patient)
        {
            return new PatientAppointmentDto()
            {
                PatientId = patient.Id,
                Name = patient.FullName,
            };
        }
    }
}
