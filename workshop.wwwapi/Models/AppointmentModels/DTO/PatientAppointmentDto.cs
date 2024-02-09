using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.AppointmentModels.DTO
{
    public class PatientAppointmentDto
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
    }
}
