using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public class DTOPerson
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
