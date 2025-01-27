using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace workshop.wwwapi.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Appointment> Appointments { get; set; } = [];

        [NotMapped]
        public string FullName {  get { return $"{FirstName} {LastName}"; } }

    }
}
