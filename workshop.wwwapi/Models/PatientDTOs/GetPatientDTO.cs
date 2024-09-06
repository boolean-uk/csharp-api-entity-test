using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{

    public class GetPatientDTO
    {
    
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        // Navigation 
        public ICollection<GetAppointmentDTO> Appointments { get; set; } = new List<GetAppointmentDTO>();
    }
}
