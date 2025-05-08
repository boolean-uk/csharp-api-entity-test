using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
/*    public enum GenderObject
    {
        Male = 1 ,
        Female = 2,
        Neutral = 3,
        Other = 4
    }*/

    //TODO: decorate class/columns accordingly    
    [Table("patients")]
    public class Patient
    {
        [Column("id")]
        public int Id { get; set; }     

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("email")]
        public string Email { get; set; }
        [Column("gender")]
        public string? Gender { get; set; }

        [Column("appointment")]
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    
    
        // constructor 
        public Patient () { }
        public Patient(string fullName, string email, string gender)
        {
            FullName = fullName;
            Email = email;
            Gender = gender;
        }   

    }
}
