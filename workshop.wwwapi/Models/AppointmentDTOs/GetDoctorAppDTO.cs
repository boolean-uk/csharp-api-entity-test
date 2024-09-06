using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{

    public class GetDoctorAppDTO
    {
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }

    }
}
