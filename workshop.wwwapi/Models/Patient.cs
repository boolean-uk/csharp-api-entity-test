using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Models
{
    //TODO: decorate class/columns accordingly
    [Table("patients")]
    [PrimaryKey(nameof(Id))]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}
