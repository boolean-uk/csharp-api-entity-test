using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.ModelsDto
{

    public class DoctorDto
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<AppointmentDto> Appointments { get; set; }
    }
}
