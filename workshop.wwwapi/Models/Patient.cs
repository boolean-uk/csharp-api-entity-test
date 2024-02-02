using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("patient")]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }

        [Column("appointments")]
        public List<Appointment> Appointments { get; set; }
    }
}
