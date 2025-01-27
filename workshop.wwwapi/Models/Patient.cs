using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace workshop.wwwapi.Models;

//TODO: decorate class/columns accordingly   
[Table("patients")]
[PrimaryKey("Id")]
public class Patient
{
    // Update the Patient model to include decorators for the table name, primary key and column names. Make sure to use good naming conventions for postgres.

    [Column("id")] public int Id { get; set; }

    [Column("full_name")] public string FullName { get; set; }
    
    public virtual List<Appointment>? Appointments { get; set; }
}
