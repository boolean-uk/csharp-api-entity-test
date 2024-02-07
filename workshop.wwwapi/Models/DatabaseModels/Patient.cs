using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models.DatabaseModels
{
    //TODO: decorate class/columns accordingly    
    public class Patient
    {
        [Column("patient_id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
