using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.AppointmentModels.DTO
{
    public class DoctorAppointmentDto
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
    }
}