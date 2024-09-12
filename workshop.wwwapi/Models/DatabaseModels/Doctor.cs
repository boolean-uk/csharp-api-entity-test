using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models.DatabaseModels
{
    //TODO: decorate class/columns accordingly    
    public class Doctor
    {
        [Column("doctor_id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
        public List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
