using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using workshop.wwwapi.Models.Attributes;
using workshop.wwwapi.Models.Interface;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly    
    [Table("patients")]
    public class Patient : ISeedable, ICustomModel
    {
        [Key]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("appointments")]
        public ICollection<Appointment> Appointments{ get; set; } = new List<Appointment>();
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
