using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DoctorModels.DTO
{

    public class DoctorDoctorDto
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public ICollection<AppointmentDoctorDto> Appointments { get; set; }
    }
}
