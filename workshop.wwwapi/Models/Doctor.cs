using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    //
    [Table("doctor")]
    public class Doctor
    {
        [Column ("id")]
        public int Id { get; set; }
//
        [Column ("full_name")]
        public string FullName { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
