using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using workshop.wwwapi.Enums;

namespace workshop.wwwapi.Models
{
    
    public class GetPatientAppDTO
    {
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentType AppointmentType { get; set; }

    }
}
