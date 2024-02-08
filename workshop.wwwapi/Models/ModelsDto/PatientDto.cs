using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.ModelsDto
{
    public class PatientDto
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<AppointmentDto> Appointments { get; set; }
    }
}
