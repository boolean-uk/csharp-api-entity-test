using System.ComponentModel.DataAnnotations.Schema;

namespace workshop.wwwapi.Models
{

    public class Doctor
    {        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Appointment> Appointments { get; set; } = [];

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }
}
