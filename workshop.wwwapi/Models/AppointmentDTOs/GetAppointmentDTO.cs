using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.AppointmentDTOs
{
    public class GetAppointmentDTO
    {

        public DateTime AppointmentDate { get; set; }

        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public Guid PatientId { get; set; }
        public string PatientName { get; set; }

        
    }
}
