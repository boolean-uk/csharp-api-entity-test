using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.DTOs.AppointmentGets
{
    public class AppointmentPatientGet
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
