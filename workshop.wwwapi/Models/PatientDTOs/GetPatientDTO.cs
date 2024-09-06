using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{

    public class GetPatientDTO
    {
    
        public Guid Id { get; set; }

        public string FullName { get; set; }

        // Navigation 
        public ICollection<GetAppointmentDTO> Appointments { get; set; } = new List<GetAppointmentDTO>();
    }
}
