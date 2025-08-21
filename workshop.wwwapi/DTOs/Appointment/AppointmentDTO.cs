using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.DTOs.Person;

namespace workshop.wwwapi.DTOs.Appointment
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public NestedPersonForAppointmentDTO Doctor { get; set; }
        public NestedPersonForAppointmentDTO Patient { get; set; }
    }
}
